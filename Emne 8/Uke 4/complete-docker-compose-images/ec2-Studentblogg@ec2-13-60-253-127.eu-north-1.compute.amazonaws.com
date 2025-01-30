services:
  web:
    container_name: stud-blogg-web-compose
    image: gloxie/complete-docker-compose-build-web
    ports:
      - "80:80"
      - "81:81"
    depends_on:
      - api
    networks:
      - student-blogg-nett
  
  api:
    container_name: stud-blogg-api-compose
    image: gloxie/complete-docker-compose-build-api
    ports:
      - "8080:8080"
    depends_on:
      - db
    networks:
      - student-blogg-nett
    environment:
      - ConnectionStrings__DefaultConnection=Server=stud-blogg-db-compose;Database=ga_emne7_avansert;User ID=ga-app;Password=ga-5ecret-%;
    
  db:
    container_name: stud-blogg-db-compose
    image: gloxie/complete-docker-compose-build-db
    ports:
      - "3366:3306"
    volumes:
      - student-blogg-volume:/var/lib/mysql
    networks:
      - student-blogg-nett


networks:
  student-blogg-nett:
    driver: bridge

volumes:
  student-blogg-volume: