<b>DeliVeggie</b>

In DeliVeggie, we have two web pages:

The product list page, which displays a list of products<br/>
Product details page which displays the details of a selected product

<b>Technologies Used</b>

Data Base: MongoDB <br/>
Back End: .NET Core 3.1<br/>
Front End: Angular 12<br/>
Message Broker: RabbitMq and EasyNetQ<br/>

Angular SPA is used to display product list and product details. Contains two pages(product list page & product details page).<br/>
Two components are used : list.component & details.component.<br/>
Service named product.service is used to get data from API.<br/>

DeliVeggie.Gateway (API Gateway) is used to centralize, manage, and monitor the non-functional requirements of this application, orchestrate the cross-functional microservices, and reduce roundtrips. DeliVeggie.Gateway will act as a API gate way here. Moving forward we can use services like Azure APIM as gateway for microservices.

DeliVeggie.Services.Products will act as a microservice here

ProductMdo : This is used for product data.<br/>
ProductManager : Manager class will fetch the data.<br/>
ProductRepository : Repository class will help to retrieve data from data base.<br/>

<b>Deployment</b>

Docker with Container Orchestrator Support.<br/>
Kubernetes on Docker Desktop.

![alt text](https://github.com/anishsm7/deliveggie/blob/main/Docker.png)






