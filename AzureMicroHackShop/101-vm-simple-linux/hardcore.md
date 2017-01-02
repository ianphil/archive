# Azure CLI - Linux VM

- STEP ONE: Update Parameter File
- STEP TWO: Run the following CMDs:

#### Create Resource Group
azure group create {RESOURCE GROUP NAME} eastus

#### Create Deployment & Deploy
azure group deployment create --template-file {file PATH} --parameter-file {FILE PATH} {RESOURCE GROUP NAME} {DEPLOYMENT NAME}