FROM mysql:8.0.33

# -e MYSQL_ROOT_PASSWORD=gokstad
ENV MYSQL_ROOT_PASSWORD=gokstad

COPY stud_blogg_db_dump.sql /docker-entrypoint-initdb.d/
COPY user_privileges.sql /docker-entrypoint-initdb.d/

# IKKE NØDVENDIG Å HA MED, men best practice
EXPOSE 3306