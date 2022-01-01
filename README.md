# Play Microservices
A simple microservice system using .NET 5 and React.js to explore asynchronous microservice communication. 
Players have an inventory of items, handled by the Play.Inventory service. They can purchase items from 
the catalogue via the Play.Catalog service.

Requires Mongo DB container running for the catalogue service, and RabbitMQ container to handle all asynchronous 
communication, start both:
```shell
cd Play.Infra
docker-compose up
```
