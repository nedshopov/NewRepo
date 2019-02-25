Read me

1. Assumptions:
During the design and implementation process I had to make various assumptions. Even though I have tried to be 
sufficiently descriptive on my code documentation I am going to point out a list of assumptions I made:

- Authentication and Authorization were not part of the current task. I assume that it will be done via JWT or another type of token.
In order to simulate an authorized logged-in user I use a shared constant with that user's ID throughout the project. It can be found 
in Shared/MockConstants.CurrentUserId.

- Requests - responses. The body and the headers of the requests are functional but far from complete. I would describe them as 
the minimum required in order for the web api to function.

- Web Api requirements. I assumed that it needs to be RESTful api with all the requirements and constraints of the 
restful service architecture - Stateless service, layered implementation - more on that later.

- The back-end framework - I feel like i have more than it was required on the back-end. The business layer is separated and not referencing
the web layer. Ideally the web layer would not reference any domain entities and data would be mapped and transfered only via Data Transfer Objects.

-Inversion of control. I assumed an inversion of control container is required, and I decided to implement it via the Structure Map.

-The front-end is the bare minimum for demonstrating communication with the api via very simple html pages, with no style sheets or additional 
javascript logic. There is a home page with a table with all available products. Each product can be added to the shopping basket.
There is a shopping basket page, where products can be added, removed, it can be cleared or checked out.

2. Design choices: 
- As mentioned before, I tried to vaguely split the solution into separate projects, representing different layers-  Business, shared and web.
Ideally the Business would be split into smaller ones - Application, Domain, Contracts and the web layer would reference only the applicaiton,
so it will not have access to domain entities. 

- I used several common design patterns for .net core web applications that contribute to more clean design and RESTful architecture: 
Command-Command handler pattern, Service request processor for processing commands, various simple helper classes: for example a modelmapper,
that maps domain objects to viewmodels, based on field definition attribute on each of their properties.

- There are 2 publically exposed web api controllers: Products and Basket. The products has only GetAll action. 
The basket one has the following request handlers:
[Get] - Get and GetById for a shopping card model;
[Post] Add and remove item from the shopping card of the current user 
and returning the updated model (in order to help the client to not need to query again);
[Put] For clearing the shopping cart and returning the new instance of it;
Checking out was not implemented as it was not part of the task. The current behavior just empties the cart.

- I used Swagger and proper documentation on each public method and public property to generate XML documentation as part of the build process
and a swagger help page.

- The client project is referencing only the shared project in order to re-use the view models. 

- Using dependency injection and interfaced services so nearly every request or call can be mocked for testing purposes or developed 
independently. 

Final words:
Overall I think I overdid the business layer and oversimplified the front end architecture.
I am treating the client library as a project only for demonstration purposes and a foundation that can be built upon.
Thanks for your time, and looking forward hearing from you!
