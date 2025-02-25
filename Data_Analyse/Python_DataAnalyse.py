# Importer les bibliothèques nécessaires
import pandas as pd
import numpy as np
from sklearn.ensemble import RandomForestClassifier
from sklearn.model_selection import train_test_split

# Classe pour gérer les données des clients
class EnergyCustomerData:
    def __init__(self, n_clients=100, seed=42):
        self.n_clients = n_clients
        self.seed = seed
        self.df = None

    def generate_data(self):
        np.random.seed(self.seed)
        data = {
            'CustomerID': range(1, self.n_clients + 1),
            'Age': np.random.randint(18, 80, self.n_clients),
            'HouseholdSize': np.random.randint(1, 6, self.n_clients),
            'WeeklyWashFreq': np.random.randint(0, 10, self.n_clients),
            'WashHour': np.random.choice(['Morning', 'Afternoon', 'Evening', 'Night'], self.n_clients),
            'HasElectricOven': np.random.choice([0, 1], self.n_clients),
            'HasElectricHeating': np.random.choice([0, 1], self.n_clients),
            'HasAirConditioning': np.random.choice([0, 1], self.n_clients),
            'MonthlyConsumption_kWh': np.random.uniform(100, 1000, self.n_clients)
        }
        self.df = pd.DataFrame(data)
        return self.df

    def get_data(self):
        if self.df is None:
            self.generate_data()
        return self.df

# Classe pour le traitement des données
class EnergyDataProcessor:
    def __init__(self, df):
        self.df = df.copy()
        self.features = None

    def feature_engineering(self, df_to_process):
        # Travaille sur une copie pour ne pas modifier self.df
        df = df_to_process.copy()
        df['WashConsumption_kWh'] = df['WeeklyWashFreq'] * 1.0
        df['TotalElectricAppliances'] = (df['HasElectricOven'] + 
                                         df['HasElectricHeating'] + 
                                         df['HasAirConditioning'])
        df['ApplianceConsumption_kWh'] = df['TotalElectricAppliances'] * 50
        df['HighUsageProfile'] = np.where((df['MonthlyConsumption_kWh'] > 600) | 
                                          (df['TotalElectricAppliances'] > 2), 1, 0)
        df = pd.get_dummies(df, columns=['WashHour'], prefix='WashHour')
        df['ConsumptionPerPerson'] = df['MonthlyConsumption_kWh'] / df['HouseholdSize']
        return df

    def define_products(self):
        self.df = self.feature_engineering(self.df)
        conditions = [
            ((self.df['MonthlyConsumption_kWh'] > 600) | (self.df['HighUsageProfile'] == 1)),
            ((self.df['MonthlyConsumption_kWh'].between(300, 600)) & 
             (self.df['TotalElectricAppliances'].between(1, 2)) & 
             (self.df['HighUsageProfile'] == 0)),
            (self.df['MonthlyConsumption_kWh'] <= 300)
        ]
        choices = ['Energy_A', 'Energy_B', 'Energy_C']
        self.df['RecommendedProduct'] = np.select(conditions, choices, default='Energy_B')

    def prepare_data(self):
        self.define_products()
        features = ['Age', 'HouseholdSize', 'WeeklyWashFreq', 'HasElectricOven', 'HasElectricHeating', 
                    'HasAirConditioning', 'MonthlyConsumption_kWh', 'WashConsumption_kWh', 
                    'TotalElectricAppliances', 'ApplianceConsumption_kWh', 'HighUsageProfile', 
                    'ConsumptionPerPerson', 'WashHour_Afternoon', 'WashHour_Evening', 
                    'WashHour_Morning', 'WashHour_Night']
        self.features = features
        X = self.df[features]
        y = self.df['RecommendedProduct']
        return X, y

    def process_new_customer(self, customer_data):
        df_new = pd.DataFrame([customer_data])
        processed_df = self.feature_engineering(df_new)
        # S’assurer que toutes les colonnes attendues par le modèle sont présentes
        for col in self.features:
            if col not in processed_df.columns:
                processed_df[col] = 0  # Remplir les colonnes manquantes (ex. : WashHour_*) avec 0
        return processed_df[self.features]  # Retourner uniquement les colonnes utilisées par le modèle

# Classe pour le modèle de recommandation
class EnergyProductRecommender:
    def __init__(self):
        self.model = RandomForestClassifier(n_estimators=100, random_state=42)
        self.features = None

    def train(self, X, y):
        self.features = X.columns
        X_train, _, y_train, _ = train_test_split(X, y, test_size=0.2, random_state=42)
        self.model.fit(X_train, y_train)

    def predict(self, new_customer):
        return self.model.predict(new_customer)

# Classe principale : Pipeline de recommandation
class EnergyRecommendationPipeline:
    def __init__(self, n_clients=100, seed=42):
        self.data_generator = EnergyCustomerData(n_clients, seed)
        self.processor = None
        self.recommender = EnergyProductRecommender()

    def initialize_and_train(self):
        df = self.data_generator.get_data()
        self.processor = EnergyDataProcessor(df)
        X, y = self.processor.prepare_data()
        self.recommender.train(X, y)

    def recommend_product(self, customer_profile):
        if self.processor is None:
            raise ValueError("Le pipeline doit être initialisé et entraîné d’abord avec initialize_and_train()")
        processed_customer = self.processor.process_new_customer(customer_profile)
        prediction = self.recommender.predict(processed_customer)
        return prediction[0]

# Utilisation du pipeline
pipeline = EnergyRecommendationPipeline(n_clients=100)
pipeline.initialize_and_train()

# Tester sur des profils clients bruts
test_customers = [
    {'CustomerID': 101, 'Age': 25, 'HouseholdSize': 1, 'WeeklyWashFreq': 2, 'WashHour': 'Evening',
     'HasElectricOven': 0, 'HasElectricHeating': 0, 'HasAirConditioning': 1, 'MonthlyConsumption_kWh': 200},
    {'CustomerID': 102, 'Age': 60, 'HouseholdSize': 4, 'WeeklyWashFreq': 8, 'WashHour': 'Afternoon',
     'HasElectricOven': 1, 'HasElectricHeating': 1, 'HasAirConditioning': 0, 'MonthlyConsumption_kWh': 750},
    {'CustomerID': 103, 'Age': 40, 'HouseholdSize': 2, 'WeeklyWashFreq': 4, 'WashHour': 'Morning',
     'HasElectricOven': 1, 'HasElectricHeating': 0, 'HasAirConditioning': 1, 'MonthlyConsumption_kWh': 450}
]

print("Recommandations pour les nouveaux clients :")
for i, customer in enumerate(test_customers, 1):
    recommendation = pipeline.recommend_product(customer)
    print(f"Client {i} (CustomerID: {customer['CustomerID']}) : Produit recommandé = {recommendation}")