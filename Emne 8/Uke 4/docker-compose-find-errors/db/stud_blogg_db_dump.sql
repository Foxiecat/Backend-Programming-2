CREATE DATABASE  IF NOT EXISTS `ga_emne7_avansert` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ga_emne7_avansert`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: ga_emne7_avansert
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Comments`
--

DROP TABLE IF EXISTS `Comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Comments` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `PostId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DateCommented` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Comments_PostId` (`PostId`),
  KEY `IX_Comments_UserId` (`UserId`),
  CONSTRAINT `FK_Comments_Posts_PostId` FOREIGN KEY (`PostId`) REFERENCES `Posts` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Comments_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Comments`
--

LOCK TABLES `Comments` WRITE;
/*!40000 ALTER TABLE `Comments` DISABLE KEYS */;
/*!40000 ALTER TABLE `Comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Logs`
--

DROP TABLE IF EXISTS `Logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Logs` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Timestamp` varchar(100) DEFAULT NULL,
  `Level` varchar(15) DEFAULT NULL,
  `Template` text,
  `Message` text,
  `Exception` text,
  `Properties` text,
  `_ts` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Logs`
--

LOCK TABLES `Logs` WRITE;
/*!40000 ALTER TABLE `Logs` DISABLE KEYS */;
INSERT INTO `Logs` VALUES (1,'2025-01-06 16:30:33.477+01:00','Warning','The ASP.NET Core developer certificate is not trusted. For information about trusting the ASP.NET Core developer certificate, see https://aka.ms/aspnet/https-trust-dev-cert.','The ASP.NET Core developer certificate is not trusted. For information about trusting the ASP.NET Core developer certificate, see https://aka.ms/aspnet/https-trust-dev-cert.',NULL,'{\"EventId\":{\"Id\":8,\"Name\":\"DeveloperCertificateNotTrusted\"},\"SourceContext\":\"Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServer\"}','2025-01-06 15:30:43'),(2,'2025-01-06 16:31:41.757+01:00','Warning','The ASP.NET Core developer certificate is not trusted. For information about trusting the ASP.NET Core developer certificate, see https://aka.ms/aspnet/https-trust-dev-cert.','The ASP.NET Core developer certificate is not trusted. For information about trusting the ASP.NET Core developer certificate, see https://aka.ms/aspnet/https-trust-dev-cert.',NULL,'{\"EventId\":{\"Id\":8,\"Name\":\"DeveloperCertificateNotTrusted\"},\"SourceContext\":\"Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServer\"}','2025-01-06 15:31:51'),(3,'2025-01-07 10:03:27.047+01:00','Warning','The ASP.NET Core developer certificate is not trusted. For information about trusting the ASP.NET Core developer certificate, see https://aka.ms/aspnet/https-trust-dev-cert.','The ASP.NET Core developer certificate is not trusted. For information about trusting the ASP.NET Core developer certificate, see https://aka.ms/aspnet/https-trust-dev-cert.',NULL,'{\"EventId\":{\"Id\":8,\"Name\":\"DeveloperCertificateNotTrusted\"},\"SourceContext\":\"Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServer\"}','2025-01-07 09:03:36');
/*!40000 ALTER TABLE `Logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Posts`
--

DROP TABLE IF EXISTS `Posts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Posts` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Title` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DatePosted` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Posts_UserId` (`UserId`),
  CONSTRAINT `FK_Posts_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Posts`
--

LOCK TABLES `Posts` WRITE;
/*!40000 ALTER TABLE `Posts` DISABLE KEYS */;
/*!40000 ALTER TABLE `Posts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserName` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FirstName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `HashedPassword` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL,
  `IsAdminUser` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Users_Email` (`Email`),
  UNIQUE KEY `IX_Users_UserName` (`UserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES ('4a5f786d-fb68-4b67-98c5-edd47d563d52','yma','Yngve','Magnussen','yma@mail.com','$2a$11$CW83DVaAYmGw2mvSY2e6.OXtlJd06D85wgRCOtCyGVLce3BYW24Pm','2025-01-06 15:32:08.354863','2025-01-06 15:32:08.354915',0),('b29a3379-60ff-4583-8c41-af0809382459','string','string','string','string','$2a$11$tg.wDVLCAWnb0J5NUczKb.LxsctOnNgW17cBGgJ/QqpkiVXiAHdTm','2025-01-07 09:05:22.526108','2025-01-07 09:05:22.526221',0);
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20241002101749_init','8.0.8'),('20250106152451_initial','8.0.8'),('20250107085514_init2','8.0.8');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-01-07 12:11:00
