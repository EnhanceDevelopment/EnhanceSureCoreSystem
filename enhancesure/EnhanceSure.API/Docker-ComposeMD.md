# Commands for Docker-Compose
```bash```
### This will recreate the 'enhancesure-sql' container with the new volume mapping
docker-compose up -d --force-recreate 

### for User Acceptance Test Environment
docker-compose --env-file .env.uat up --build

### for Production Environment
docker-compose --env-file .env.prod up --build
