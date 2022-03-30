Application : <b>DeliVeggie</b>

In DeliVeggie, we have two web pages:

The product list page, which displays a list of products
Product details page which displays the details of a selected product

Technologies Used :

Data Base: MongoDB
Back End: .NET Core 3.1
Front End: Angular 12
Message Broker: RabbitMq and EasyNetQ

Angular SPA is used to display product list and product details. Contains two pages(product list page & product details page).
Two components are used : list.component & details.component
Service named product.service is used to get data from API.

DeliVeggie.Gateway (API Gateway) is used to centralize, manage, and monitor the non-functional requirements of this application, orchestrate the cross-functional microservices, and reduce roundtrips. DeliVeggie.Gateway will act as a API gate way here. Moving forward we can use servives like Azure APIM as gateway for microservices.

DeliVeggie.Services.Products will act as a microservice here

ProductMdo : This is used for product data
ProductManager : Manager class will fetch the data.
ProductRepository : Repository class will help to retrieve data from data base.









