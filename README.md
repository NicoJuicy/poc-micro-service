# poc-micro-service
PoC - Microservice with a gateway, healthchecks, 2 microservices and a quick frontend with IdentityServer in asp.net core

Tech: 

- Nats as message broker ( sending is used, but not receiving / handling Integration events) 
- Postgress as DocumentStore

# Note

This is a quick PoC as i am integrating microservices ( but more complete) in another project of mine.

Some minor remarks:

1. Gateway

- note microservice is ok
- contacts microservice is ok

But the gateway won't redirect to the path to notes ( it will go to contacts).

2. Frontend only gets the list/notes and is dirty :)

3. TagService / SchedulerService / Multitenancy is not implemented. The concepts are here though.

4. Using mediatR, Nats and Postgres. There was a quick PoC for integrating Nats as message broker ( and i think it works). But didn't verify it as IntegrationEvents are not used currently.
