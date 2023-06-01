# Serverless-Example
An example of a serverless application to demonstrate various techniques that can be applied when testing.
There will be 3 branches created for this system.
#### master
Base system without any tests or test projects created
#### tests-created
The base system with test projects create along with a few example tests
#### fully-tested
The full system containing all the test projects and all the tests.

# Systems Purpose
The aim of the system is to ease the creation of shopping lists. The main use flows will be:
- Add recipes with ingredients
- Select recipes for a meal plan
- Create a shopping list from the selected recipes. 

# Building
To build the application run `dotnet build` from the repository root. 

# Deployment
Deployment is carried out using Terraform files and is configured to deploy to Azure. 
To run a deployment you'll need to have installed the Terraform and Azure CLI tools on your machine and be logged into Azure via the command line.

To deploy manually to your own azure environment follow the steps below:
1. Run `dotnet publish ./RecipeApiFunction/RecipeApiFunction.csproj /p:PublishProfile=FolderProfile`
2. Create a `terraform.tfvars` file containing the below variables. 
```
resource_group_name = "{ResorceGroupName}"
location = "{AzureRegion}"
project = "shoppinglist"
environment = "dev"
recipefunctionzip = "./publish/recipe-api-function.zip"
```
3. Run `terraform plan -out main.tfplan` to create the deployment plan.
4. Run `terraform apply main.tfplan` to execute the deployment plan.

You should now have the application deployed and running on Azure. 

