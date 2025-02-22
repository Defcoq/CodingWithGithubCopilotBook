public List<TenantForDashboard> AvailableTenantsForDashboard()
 {
     try
     {
         List<TenantForDashboard> ret = new List<TenantForDashboard>();

         AppUser user = _applicationUserManager.FindByNameAsync(IdentityHelper.Identity.Name).Result;

         List<AppRole> ruoliUser = user.Groups.SelectMany(x => x.Roles).ToList();

         List<Tenant> tenantList = TenantUtils.GetAllTenants().Where(t => t.Visible).ToList();

         List<SelectionMenuTenant> selectionMenus = _selectionMenuTenantRepository.All().ToList();

         List<SelectionMenuRole> selectionMenuRoles = _selectionMenuRoleRepository.All().ToList();

         selectionMenuRoles = selectionMenuRoles
             .Where(x => ruoliUser.Any(y => y.Id == x.Ruolo.Id))
             .ToList();

         foreach (Tenant tnt in tenantList)
         {
             List<MenuTenantForDashboard> menuForTenant = selectionMenus
                 .Where(x =>
                     x.Tenant.Id == tnt.Id &&
                     x.SelectionMenu != null &&
                     (selectionMenuRoles.Any(y => y.SelectionMenu.Id == x.SelectionMenu.Id) || user.SuperAdmin == true)
                 )
                 .Select(x => x.SelectionMenu)
                 .Select(x => new MenuTenantForDashboard()
                 {
                     labelName = x.Descrizione,
                     order = x.Ordine,
                     url = x.Url
                 })
                 .OrderBy(x => x.order)
                 .ToList();

             ret.Add(new TenantForDashboard().Parse(tnt).SetMenu(menuForTenant));
         }

         if (ret.Count() <= 0)
             _logService.Fatal("Errore nella selezione del tenant, array vuoto. Controllare la cache o il database");

         return ret;
     }
     catch (Exception ex)
     {
         _logService.Fatal("Exception attivitata su AvailableTenantsForDashboard()", ex);
         return null;
     }
 }
