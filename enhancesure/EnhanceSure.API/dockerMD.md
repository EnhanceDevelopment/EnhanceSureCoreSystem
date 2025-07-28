# 🚀 EnhanceSure Docker Build/Run Guide

This guide helps developers build Docker images for the **EnhanceSure.API** project across different environments (**Dev**, **Uat**, and **Pro**).

## 📁 Dockerfile Location

All commands use the Dockerfile located at: ..\EnhanceSureCoreSystem\enhancesure\EnhanceSure.API\Dockerfile


---

## 🔧 Build and Run Arguments 

The build process uses the following argument

- `BUILD_ENV`: Specifies the environment context. This value is injected as the `ASPNETCORE_ENVIRONMENT` at runtime and is also used to determine the build configuration during publishing.
- `BUILD_CONFIGURATION`: Specifies the build configuration (Debug or Release).

---
## 🔧 Build and Run Docker Container
Run these commands from root directory **enhancesure**  

### command flags
- **-f:** finds the directory ****EnhanceSure.API/Dockerfile**** where docker file exists.
- **--build-arg:** used to set the value for **BUILD_ENV** and **BUILD_CONFIGURATION** . 
- **-p:** Maps container port 8080 (as defined in ASPNETCORE_URLS) to your localhost.
- **--name:** Optional name for the container
- **-d:** Detached mode  
- **-t:** Specifies target Image

``bash``  
#### 🧪 Development Build/Run

Use this command for **local development and testing**.   

- docker build -f EnhanceSure.API/Dockerfile --build-arg BUILD_ENV=dev --build-arg BUILD_CONFIGURATION=Debug -t enhancesure-api-dev:dev .  
- docker run -d -p 7262:7262 --name enhancesure-dev enhancesure-api-dev:dev

#### 🧪 UAT Build/Run
- docker build -f EnhanceSure.API/Dockerfile --build-arg BUILD_ENV=uat --build-arg BUILD_CONFIGURATION=Release -t enhancesure-api-uat:uat .  
- docker run -d -p 1505:1505 --name enhancesure-uat enhancesure-api-uat:uat

#### 🧪 Production Build/Run
- docker build -f EnhanceSure.API/Dockerfile --build-arg BUILD_ENV=prod --build-arg BUILD_CONFIGURATION=Release -t enhancesure-api-prod:prod .   
- docker run -d -p 1304:1304 --name enhancesure-prod enhancesure-api-prod:prod

---
## Miscellaneous Info on docker 
``bash``
#### Purging All Unused or Dangling Images, Containers, Volumes, and Networks
- **docker system prune:** Docker provides a single command that will clean up any resources — images, containers, volumes, and networks — that are dangling (not tagged or associated with a container): 
- **docker system prune -a:** To additionally remove any stopped containers and all unused images (not just dangling images), add the -a flag to the command:
#### Removing Docker Images
- **docker images -a:** Get Images list
- **docker rmi Image Image:** remove specific image
- **docker images -f dangling=true:** Lists the dangling images.
- **docker image prune:** 

#### Removing Containers
- **docker ps -a:** Lists the docker containers.
-  **docker rm ID_or_Name ID_or_Name:** Removes the specific docker container 

#### Removing Volumes
- **docker volume ls:** Lists volumes.
- **docker volume rm volume_name volume_name:** Removes specific volume
- **docker volume ls -f dangling=true:**
 Gets/Lists Dangling volumes
 - **docker volume prune:** removes the volumes(dangling)   
	 
	
	**learn more at:** [digitalocean.com](https://www.digitalocean.com/community/tutorials/how-to-remove-docker-images-containers-and-volumes)  


