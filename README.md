# OnlineMarketPlace
Simple back-end for an online marketplace.
Here is a sample of some of the products available on the site.


| Product code  | Name  |  Price |
|  001 |  Lavender heart | £9.25  |
|  002 |  Personalised cufflinks | £45.00  |
|  003 |  Kids T-shirt | £19.95 |

Following CRUD Operations are implemented as part of the RESTful API
* GET /products - A list of products, names, and prices in JSON.
* POST /product - Create a new product using posted form data.
* GET /product/{product_id} - Return a single product in JSON format.
* PUT /product/{product_id} - Update a product's name or price by id.
* DELETE /product/{product_id} - Delete a product by id.

Steps to run the Web API for OnlineMarketPlace

First, download the given Project from my GitHub repository / from article resources.
* Open the project using VS2019 or later versions
* Go to package manager console
* Add the migration by running the script : Update-Database -verbose
* The localhost SQLExpress DB should get updated with a new database named ProductContectDb 
* Run the project and execute different endpoints of the WEb API using Swagger UI
