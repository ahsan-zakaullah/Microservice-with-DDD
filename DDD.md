Domain driven design is based on the reality of business and sometimes it is also considered a hurdle 
because you need to learn the domain. DDD is about boundaries called a bounded context such as microservices.
We can use the layer approach for better understanding for developers. 
Domain Layer: Representing the concept of the business. It is heart of the business software. 
It is not dependent on any layer.
Infrastructure layer: It will define how the data will persist in the database. We can create the repositories here. 
It can be dependent on the domain layer.

Application Layer: It is defining the job of the software and it can depend on the insfrastructure and domain layer.
It should be thin. It cannot contain the business logic or knowledge.
Only coordinate with the interface to interact with service.


Suggestions for current solution.
Domain layer should not depend on any other layer and  should be POCO. 
In our case it is dependent on a common layer so we can avoid this dependency.
We can define the separate layer to define the business logic as services. So application layer can communicate with them.
