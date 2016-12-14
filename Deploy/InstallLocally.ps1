Write-Host "------------------------------------------------------------------------------------------------"
Write-Host "Starting " $MyInvocation.MyCommand.Name
Write-Host "------------------------------------------------------------------------------------------------"
Write-Host "Importing modules"

Import-Module DeploymentUtils-iis
Import-Module DeploymentUtils-utils -Force
Import-Module WebAdministration

#get current and parent folders
$deployFolder = $PSScriptRoot
$rootFolder = Split-Path -Path $deployFolder -Parent

# copy the configuration files into their folder
#$configFolder = Join-Path $rootFolder "Config"
#get config files
#$configFiles = Join-Path $configFolder "\*"
#finally copy the config files
#Copy-Item $configFiles $rootFolder -Recurse -Container -Force


# install website
Write-Host "------------------------------------------------------------------------------------------------"
Write-Host "book-api website installation"
Write-Host "------------------------------------------------------------------------------------------------"

$WebFullName = "book-api.api"
$WebAppPool = "book-api.api.AppPool"
$WebBinding = "book-api.api.local"
$WebPhysicalPath = Join-Path $rootFolder "Buku.API"

Write-Host "WebFullName" = $WebFullName
Write-Host "WebAppPool" = $WebAppPool
Write-Host "WebBinding" = $WebBinding
Write-Host "WebPhysicalPath" = $WebPhysicalPath

#create application pool and website
Stop-ApplicationPool -applicationPoolName $WebAppPool
Create-ApplicationPool -applicationPoolName $WebAppPool -identityType "LocalService"
Create-Website -websiteName $WebFullName -physicalPath $WebPhysicalPath -applicationPoolName $WebAppPool -websiteBinding $WebBinding -anonymousAuthentication   
Start-ApplicationPool -applicationPoolName $WebAppPool
#add hosts file entries
Write-Host "Add records in hosts file" 
Add-Host-Record  $WebBinding "127.0.0.1"


#$WebPhysicalPath = Join-Path $rootFolder "EHS.Website"
#Start-Process -FilePath "npm.cmd" 