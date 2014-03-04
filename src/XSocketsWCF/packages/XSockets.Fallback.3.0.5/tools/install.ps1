param($installPath, $toolsPath, $package, $project)

Write-Host "If running .NET 4.0 register the XSockets fallback controller as..." -ForegroundColor DarkRed   
Write-Host 'routes.MapRoute("Fallback","{controller}/{action}",new {controller = "Fallback", action = "Init"},new[] {"XSockets.Longpolling"});' -ForegroundColor DarkRed   
Write-Host ""
Write-Host "If running .NET 4.5 the web api controller is registered automatically, you will not have to do anything." -ForegroundColor DarkRed   
Write-Host ""
Write-Host "Note: Regardless of 4.0 or 4.5 you have to include the correct javascript file" -ForegroundColor DarkRed   

