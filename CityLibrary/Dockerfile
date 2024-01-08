# Build stage
FROM maven:3.8.5-openjdk-17 AS build
COPY src /home/app/src
COPY pom.xml /home/app
RUN mvn -f /home/app/pom.xml clean package

# Run stage
FROM openjdk:17-jdk-slim
COPY --from=build /home/app/target/city-0.0.1-SNAPSHOT.jar /app/city.jar
WORKDIR /app
EXPOSE 8081
ENTRYPOINT ["java","-jar","city.jar"]