# Foreword

This is just a PoC, treat it as one, what is described as working works. It served it's goal :)

# Requirements
- Docker/local with Nats running
- Docker/local with Postgress running 
- Change the appsettings on the NoteService.Api/ContactsService.Api ( postgress connstring + Nats IP)

# poc-micro-service
PoC - Microservice with a gateway, healthchecks, 2 microservices and a quick frontend with IdentityServer in asp.net core 3.0

### Tech: 

- Nats as message broker ( sending is implemented, but not handling them) 
- Postgress as DocumentStore
- Ocelot as gateway

# Note

This is a quick PoC as i am integrating microservices ( but more complete) in another project of mine.

Some minor remarks:

1. Gateway

- note microservice is ok
- contacts microservice is ok

But the gateway won't redirect to the path to notes ( it will go to contacts).

2. Frontend only gets the list/notes and is dirty :), used it to test RazorPages quickly

3. TagService / SchedulerService / Multitenancy is not implemented. The concepts are here though.

4. Using mediatR, Nats and Postgres. There was a quick PoC for integrating Nats as message broker ( and i think it works). But didn't verify it as IntegrationEvents are not yet handled.


