-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: comp
-- ------------------------------------------------------
-- Server version	8.0.42

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
-- Table structure for table `batch_details`
--

DROP TABLE IF EXISTS `batch_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `batch_details` (
  `batch_detail_id` int NOT NULL AUTO_INCREMENT,
  `batch_id` int NOT NULL,
  `product_id` int NOT NULL,
  `cost_price` int NOT NULL,
  `quantity_recived` int NOT NULL,
  PRIMARY KEY (`batch_detail_id`),
  KEY `batch_id` (`batch_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `batch_details_ibfk_1` FOREIGN KEY (`batch_id`) REFERENCES `batches` (`batch_id`),
  CONSTRAINT `batch_details_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `batch_details`
--

LOCK TABLES `batch_details` WRITE;
/*!40000 ALTER TABLE `batch_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `batch_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `batches`
--

DROP TABLE IF EXISTS `batches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `batches` (
  `batch_id` int NOT NULL AUTO_INCREMENT,
  `batch_name` varchar(100) NOT NULL,
  `supplier_id` int NOT NULL,
  `recieved_date` datetime DEFAULT NULL,
  PRIMARY KEY (`batch_id`),
  KEY `supplier_id` (`supplier_id`),
  CONSTRAINT `batches_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `batches`
--

LOCK TABLES `batches` WRITE;
/*!40000 ALTER TABLE `batches` DISABLE KEYS */;
/*!40000 ALTER TABLE `batches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `category_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`category_id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer_bill_details`
--

DROP TABLE IF EXISTS `customer_bill_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer_bill_details` (
  `Bill_detail_ID` int NOT NULL AUTO_INCREMENT,
  `Bill_id` int NOT NULL,
  `product_id` int DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `discount` int DEFAULT '0',
  `status` enum('bill','invoice') NOT NULL,
  `warranty` varchar(50) DEFAULT NULL,
  `warranty_from` date DEFAULT NULL,
  `warranty_till` date DEFAULT NULL,
  PRIMARY KEY (`Bill_detail_ID`),
  KEY `customerbilldetail_ibfk_2` (`product_id`),
  KEY `customerbilldetail_ibfk_1` (`Bill_id`),
  CONSTRAINT `customerbilldetail_ibfk_1` FOREIGN KEY (`Bill_id`) REFERENCES `customerbills` (`BillID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `customerbilldetail_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_bill_details`
--

LOCK TABLES `customer_bill_details` WRITE;
/*!40000 ALTER TABLE `customer_bill_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer_bill_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customerbills`
--

DROP TABLE IF EXISTS `customerbills`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customerbills` (
  `BillID` int NOT NULL AUTO_INCREMENT,
  `CustomerID` int NOT NULL,
  `SaleDate` date NOT NULL,
  `total_price` int DEFAULT NULL,
  `paid_amount` int DEFAULT NULL,
  PRIMARY KEY (`BillID`),
  KEY `CustomerID` (`CustomerID`),
  CONSTRAINT `customerbills_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`customer_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerbills`
--

LOCK TABLES `customerbills` WRITE;
/*!40000 ALTER TABLE `customerbills` DISABLE KEYS */;
/*!40000 ALTER TABLE `customerbills` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customerpayments`
--

DROP TABLE IF EXISTS `customerpayments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customerpayments` (
  `c_payment_id` int NOT NULL AUTO_INCREMENT,
  `customer_BillID` int NOT NULL,
  `Payed_amount` int DEFAULT NULL,
  `pending_amount` int DEFAULT NULL,
  `customer_id` int DEFAULT NULL,
  PRIMARY KEY (`c_payment_id`),
  KEY `fk_customer_payment` (`customer_BillID`),
  KEY `fk_customerpayments_2` (`customer_id`),
  CONSTRAINT `fk_customer_payment` FOREIGN KEY (`customer_BillID`) REFERENCES `customerbills` (`BillID`),
  CONSTRAINT `fk_customerpayments_2` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerpayments`
--

LOCK TABLES `customerpayments` WRITE;
/*!40000 ALTER TABLE `customerpayments` DISABLE KEYS */;
/*!40000 ALTER TABLE `customerpayments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customerpricerecord`
--

DROP TABLE IF EXISTS `customerpricerecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customerpricerecord` (
  `record_id` int NOT NULL AUTO_INCREMENT,
  `customer_id` int NOT NULL,
  `date` date NOT NULL,
  `payment` decimal(10,2) NOT NULL,
  `BillID` int NOT NULL,
  PRIMARY KEY (`record_id`),
  KEY `fk_customerpricerecord_customer` (`customer_id`),
  KEY `idx_cpr_bill` (`BillID`),
  KEY `idx_cpr_cust_bill_date` (`customer_id`,`BillID`,`date`),
  CONSTRAINT `fk_cpr_bill` FOREIGN KEY (`BillID`) REFERENCES `customerbills` (`BillID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_customerpricerecord_customer` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`),
  CONSTRAINT `cpr_chk_payment_nonneg` CHECK ((`payment` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerpricerecord`
--

LOCK TABLES `customerpricerecord` WRITE;
/*!40000 ALTER TABLE `customerpricerecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `customerpricerecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `customer_id` int NOT NULL AUTO_INCREMENT,
  `type` enum('Walk-in','Regular') NOT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`customer_id`),
  KEY `idx_customers_type` (`type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory` (
  `inventory_id` int NOT NULL AUTO_INCREMENT,
  `product_id` int NOT NULL,
  `sale_price` int DEFAULT NULL,
  `quantity_in_stock` int DEFAULT NULL,
  PRIMARY KEY (`inventory_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `inventory_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `product_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `category_id` int NOT NULL,
  PRIMARY KEY (`product_id`),
  KEY `idx_products_name` (`name`),
  KEY `category_id` (`category_id`),
  CONSTRAINT `category_id` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_order`
--

DROP TABLE IF EXISTS `purchase_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchase_order` (
  `purchase_order_id` int NOT NULL AUTO_INCREMENT,
  `supplier_id` int NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`purchase_order_id`),
  KEY `supplier_id_idx` (`supplier_id`),
  CONSTRAINT `supplier_id` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order`
--

LOCK TABLES `purchase_order` WRITE;
/*!40000 ALTER TABLE `purchase_order` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchase_order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_order_details`
--

DROP TABLE IF EXISTS `purchase_order_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchase_order_details` (
  `purchase_order_details_id` int NOT NULL AUTO_INCREMENT,
  `purchase_order_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int DEFAULT NULL,
  PRIMARY KEY (`purchase_order_details_id`),
  KEY `purchase_order_id_idx` (`purchase_order_id`),
  KEY `product_id_idx` (`product_id`),
  CONSTRAINT `product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`),
  CONSTRAINT `purchase_order_id` FOREIGN KEY (`purchase_order_id`) REFERENCES `purchase_order` (`purchase_order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order_details`
--

LOCK TABLES `purchase_order_details` WRITE;
/*!40000 ALTER TABLE `purchase_order_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchase_order_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier_bill_details`
--

DROP TABLE IF EXISTS `supplier_bill_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplier_bill_details` (
  `Bill_detail_ID` int NOT NULL AUTO_INCREMENT,
  `supplier_Bill_ID` int NOT NULL,
  `product_id` int DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  PRIMARY KEY (`Bill_detail_ID`),
  KEY `supplierbilldetail_ibfk_2` (`product_id`),
  KEY `supplierbilldetail_ibfk_1` (`supplier_Bill_ID`),
  CONSTRAINT `supplierbilldetail_ibfk_1` FOREIGN KEY (`supplier_Bill_ID`) REFERENCES `supplierbills` (`supplier_Bill_ID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `supplierbilldetail_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier_bill_details`
--

LOCK TABLES `supplier_bill_details` WRITE;
/*!40000 ALTER TABLE `supplier_bill_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplier_bill_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplierbills`
--

DROP TABLE IF EXISTS `supplierbills`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplierbills` (
  `supplier_Bill_ID` int NOT NULL AUTO_INCREMENT,
  `supplier_id` int NOT NULL,
  `Date` date NOT NULL,
  `total_price` int DEFAULT NULL,
  `batch_id` int DEFAULT NULL,
  PRIMARY KEY (`supplier_Bill_ID`),
  KEY `supplier_id` (`supplier_id`),
  KEY `fk_sb_2` (`batch_id`),
  CONSTRAINT `fk_sb_2` FOREIGN KEY (`batch_id`) REFERENCES `batches` (`batch_id`),
  CONSTRAINT `supplierbills_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplierbills`
--

LOCK TABLES `supplierbills` WRITE;
/*!40000 ALTER TABLE `supplierbills` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplierbills` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplierpayments`
--

DROP TABLE IF EXISTS `supplierpayments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplierpayments` (
  `payment_id` int NOT NULL AUTO_INCREMENT,
  `supplier_id` int DEFAULT NULL,
  `supplier_Bill_ID` int NOT NULL,
  `Payed_amount` int DEFAULT NULL,
  `pending_amount` int DEFAULT NULL,
  PRIMARY KEY (`payment_id`),
  KEY `fk_supplier_payment` (`supplier_Bill_ID`),
  KEY `fk_supplierpayments_2` (`supplier_id`),
  CONSTRAINT `fk_supplier_payment` FOREIGN KEY (`supplier_Bill_ID`) REFERENCES `supplierbills` (`supplier_Bill_ID`),
  CONSTRAINT `fk_supplierpayments_2` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplierpayments`
--

LOCK TABLES `supplierpayments` WRITE;
/*!40000 ALTER TABLE `supplierpayments` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplierpayments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplierpricerecord`
--

DROP TABLE IF EXISTS `supplierpricerecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplierpricerecord` (
  `supplier_record_id` int NOT NULL AUTO_INCREMENT,
  `supplier_id` int NOT NULL,
  `date` date NOT NULL,
  `payment` decimal(10,2) NOT NULL,
  `supplier_Bill_ID` int NOT NULL,
  PRIMARY KEY (`supplier_record_id`),
  KEY `fk_supplierpricerecord_customer` (`supplier_id`),
  KEY `idx_spr_bill` (`supplier_Bill_ID`),
  KEY `idx_spr_cust_bill_date` (`supplier_id`,`supplier_Bill_ID`,`date`),
  CONSTRAINT `fk_spr_bill` FOREIGN KEY (`supplier_Bill_ID`) REFERENCES `supplierbills` (`supplier_Bill_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_supplierpricerecord_customer` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplierpricerecord`
--

LOCK TABLES `supplierpricerecord` WRITE;
/*!40000 ALTER TABLE `supplierpricerecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplierpricerecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliers` (
  `supplier_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`supplier_id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `full_name` varchar(100) DEFAULT NULL,
  `role` enum('Admin','Technician','Sales') NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`),
  KEY `idx_users_username` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
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

-- Dump completed on 2025-07-01  5:56:55
