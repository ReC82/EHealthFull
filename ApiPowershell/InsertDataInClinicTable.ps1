# Define the API endpoint for adding data
$url = "http://localhost:8080/saveClinic"

# Set the content type to JSON in the headers
$h = @{
    'Content-Type' = 'application/json'
}

$nbr = 5

for ($i = 1; $i -le $nbr; $i++) {
    $rand = Get-Random -Minimum 100 -Maximum 999
    $dataToAdd = @{
        "id"      = Get-Random -Minimum 100 -Maximum 999
        "name"    = "Hopital No" + $rand
        "address" = "rue de la flemme $rand"
    }

    
    $jsonData = $dataToAdd | ConvertTo-Json

    try {
       
        $r = Invoke-RestMethod -Uri $url -Method Post -Headers $h -Body $jsonData

        
        Write-Host "API Response for Request ${i}:${r}"
        
    } catch {
        Write-Host "Error for Request " + ${i}:" +  $($_.Exception.Message)"
    }

    
    Start-Sleep -Seconds 1
}
