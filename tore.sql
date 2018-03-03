-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: den1.mysql1.gear.host    Database: toredatabase
-- ------------------------------------------------------
-- Server version	5.6.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `questions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category` varchar(255) NOT NULL,
  `question` varchar(767) NOT NULL,
  `Correct_Answer` varchar(255) NOT NULL DEFAULT 'Not chosen yet',
  `answer_A` varchar(767) DEFAULT NULL,
  `answer_B` varchar(767) DEFAULT NULL,
  `answer_C` varchar(767) DEFAULT NULL,
  `answer_D` varchar(767) DEFAULT NULL,
  `normal` tinyint(1) DEFAULT NULL,
  `Details` varchar(255) DEFAULT 'No Details',
  PRIMARY KEY (`id`),
  UNIQUE KEY `question` (`question`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
INSERT INTO `questions` VALUES (1,'Math','What is 2+2?','4','8','2','4','10',1,'Addition'),(2,'Math','What is 2*2?','4','9','4','5','6',1,'Multiplication'),(3,'Math','What is the 9 divided by 3?','3','5','7','2','3',1,'Division'),(4,'Math','What is the 10 divided by 5?','5','2','8','9','1',1,'Division'),(5,'Math','What is the 11 squared?','121','99','121','22','33',1,'Powers'),(6,'Breaking','Given a non-real circumference X of a sphere, the inverse tangent of x is inversely proportionate the natural logarithm of a tetrahedron with a base area of y. If the height of the tetrahedron is an imaginary number, and y is a representation of the derivative using the limit definition where x is undefined, compute the ratio of the density matrix of circumference X to base Y. ','???????  ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ???????','???????  ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ???????','???????  ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ???????','???????  ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ???????','???????  ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ??????? ???????',0,'No Details'),(7,'Insane','What is the meaning of life?','To conform and obey to the natural cycle of chains in society.','To conform and obey to the natural cycle of chains in society.','To conform and obey to the natural cycle of chains in society.','To conform and obey to the natural cycle of chains in society.','To conform and obey to the natural cycle of chains in society.',0,'No Details'),(8,'Insane','Are men born good, evil, or neutral?','Evil','Evil','Evil','Evil','Evil',0,'No Details'),(9,'Insane','Does life have meaning?','No','No','No','No','No',0,'No Details'),(10,'Insane','Which is more important: Your life or a feather?','A feather','A feather','A feather','A feather','A feather',0,'No Details'),(11,'Math','What is 12+82?','94','52','64','96','94',1,'Addition'),(12,'Math','What is 53+9?','62','53','64','42','62',1,'Addition'),(13,'Math','What is 9+0?','9','9','91','90','10',1,'Addition'),(14,'Math','What is 1000 + 1000?','2000','720','2000','1000','4000',1,'Addition'),(15,'Math','What is 72+90?','162','162','80','18','41',1,'Addition'),(16,'Insane','How does one find happiness?','You can\'t','You can\'t','You can\'t','You can\'t','You can\'t',1,'No Details'),(17,'Insane','How can a person achieve true freedom?','You don\'t','You don\'t','You don\'t','You don\'t','You don\'t',0,'No Details'),(18,'Math','What is 90 + 90?','180','170','150','180','160',1,'Addition'),(19,'Insane','True/False: Murder is an act of kindness','True','True','True','True','True',0,'No Details'),(20,'Math','What is 15+90?','105','105','85','90','100',1,'Addition'),(21,'Math','What is 18+0?','18','18','9','180','19',1,'Addition'),(22,'Nath','What is 70+10','80','90','70','20','80',1,'Addition'),(23,'Math','What is 42+94?','136','139','136','159','132',1,'Addition'),(24,'Math','What is 82 + 82?','164','30','218','164','521',1,'Addition'),(25,'Math','What is 64+921?','985','129','985','1089','1029',1,'Addition'),(26,'Math','What is 78*2?','156','321','53','156','891',1,'Multiplication'),(27,'Math','What is 5*12?','60','60','41','50','21',1,'Multiplication'),(28,'Math','What is 15*3?','45','43','45','21','54',1,'Multiplication'),(29,'Math','What is 72*1?','71','72','81','144','219',1,'Multiplication'),(30,'Math','What is 50*20?','100','100','200','50','25',1,'Multiplication'),(31,'Math','What is 81*10?','810','81','8100','810','8.1',1,'Multiplication');
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Jane Doe','RzjR9731',''),(2,'Restk','1q2w3e4r5t6y','liuH2122@aguafria.org');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-03 10:49:51
