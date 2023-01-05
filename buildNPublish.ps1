#Build front End
# Pre requerimientos: 
# Azure CLI 
# Kubernetes CLI
	# az aks install-cli
# Docker Desktop


# 1.- Loggearse a Azure.
# az login

# 2.- Loggearse al container registry
# az acr login --name kubopsDemoACR

# 3.- Loggearse al Kubernetes
# az aks get-credentials --resource-group Kubops --name myAKSCluster



Write-Output "Building Front end"
docker build -t kubopsdemoacr.azurecr.io/petclinicfront:latest .\PetclinicFront
if ($? -ne 1) {
    Write-Output "Error while building docker image"
}

Write-Output "Pushing latest version to Docker Registry"
docker push kubopsdemoacr.azurecr.io/petclinicfront:latest
if ($? -ne 1) {
    Write-Output "Error while pushing docker image"
}


Write-Output "Building Clients Microservice"
docker build -t kubopsdemoacr.azurecr.io/microduenos:latest .\MicroDuenos
docker push kubopsdemoacr.azurecr.io/microduenos:latest

Write-Output "Building Vets Microservice"
docker build -t kubopsdemoacr.azurecr.io/microvets:latest .\MicroVets
docker push kubopsdemoacr.azurecr.io/microvets:latest

kubectl apply -f .\kubdeploy.yaml