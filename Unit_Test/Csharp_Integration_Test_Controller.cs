[HttpPost]
public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
{
    if (!ModelState.IsValid)
        return BadRequest("Invalid request");

    var order = await _orderService.CreateOrderAsync(request);
    var result = await _externalApiClient.SendOrderToWarehouse(order);

    if (!result.Success)
        return StatusCode(500, "Failed to send order to warehouse");

    return Ok(order);
}

