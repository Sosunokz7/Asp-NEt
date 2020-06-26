CREATE DATABASE  IF NOT EXISTS `analysis_workers` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `analysis_workers`;
-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: analysis_workers
-- ------------------------------------------------------
-- Server version	8.0.20

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
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departments` (
  `Id_department` mediumint unsigned NOT NULL,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id_department`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
INSERT INTO `departments` VALUES (1,'One'),(2,'Two');
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `Id_employee` int unsigned NOT NULL AUTO_INCREMENT,
  `Surname` varchar(35) NOT NULL,
  `Name` varchar(25) DEFAULT NULL,
  `Midle_name` varchar(30) DEFAULT NULL,
  `Deportamen` mediumint unsigned NOT NULL,
  `Work` mediumint unsigned NOT NULL,
  `Experience` tinyint(2) unsigned zerofill DEFAULT '00',
  PRIMARY KEY (`Id_employee`),
  KEY `_idx` (`Deportamen`),
  KEY ` _idx` (`Work`),
  CONSTRAINT `Depart` FOREIGN KEY (`Deportamen`) REFERENCES `departments` (`Id_department`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Work` FOREIGN KEY (`Work`) REFERENCES `work` (`Id_work`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'Горин','Анатолий','Анато',1,1,77),(2,'42','420','7',2,2,44);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `work`
--

DROP TABLE IF EXISTS `work`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `work` (
  `Id_work` mediumint unsigned NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id_work`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `work`
--

LOCK TABLES `work` WRITE;
/*!40000 ALTER TABLE `work` DISABLE KEYS */;
INSERT INTO `work` VALUES (1,'Грузчик'),(2,'Бухгал');
/*!40000 ALTER TABLE `work` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `work_employee`
--

DROP TABLE IF EXISTS `work_employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `work_employee` (
  `Id_employe` int unsigned NOT NULL AUTO_INCREMENT,
  `Yeаr` smallint unsigned DEFAULT NULL,
  `Month` tinyint unsigned NOT NULL,
  `Plan_fact` varchar(65) DEFAULT NULL,
  PRIMARY KEY (`Id_employe`),
  CONSTRAINT `Employee` FOREIGN KEY (`Id_employe`) REFERENCES `employee` (`Id_employee`),
  CONSTRAINT `work_employee_chk_1` CHECK (((`Month` >= 1) and (`Month` <= 12))),
  CONSTRAINT `work_employee_year_1` CHECK ((`Yeаr` >= 1850))
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `work_employee`
--

LOCK TABLES `work_employee` WRITE;
/*!40000 ALTER TABLE `work_employee` DISABLE KEYS */;
INSERT INTO `work_employee` VALUES (1,2003,4,'0'),(2,2004,5,'1');
/*!40000 ALTER TABLE `work_employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'analysis_workers'
--

--
-- Dumping routines for database 'analysis_workers'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27  2:47:36
