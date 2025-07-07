-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: computer
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
  CONSTRAINT `batch_details_ibfk_1` FOREIGN KEY (`batch_id`) REFERENCES `batches` (`batch_id`) ON DELETE CASCADE,
  CONSTRAINT `batch_details_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `batch_details`
--

LOCK TABLES `batch_details` WRITE;
/*!40000 ALTER TABLE `batch_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `batch_details` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_after_batch_purchase` AFTER INSERT ON `batch_details` FOR EACH ROW BEGIN
  -- Log the purchase
  INSERT INTO inventory_log (
    product_id, change_type, quantity_change, remarks
  ) VALUES (
    NEW.product_id, 'purchase', NEW.quantity_recived,
    'Added from Batch details automatically'
  );

  -- Check if product exists in inventory
  IF EXISTS (
    SELECT 1 FROM inventory WHERE product_id = NEW.product_id
  ) THEN
    -- Update inventory quantity if product exists
    UPDATE inventory
    SET quantity_in_stock = quantity_in_stock + NEW.quantity_recived
    WHERE product_id = NEW.product_id;
  ELSE
    -- Insert new product into inventory if not exists
    INSERT INTO inventory (
      product_id, quantity_in_stock, sale_price
    ) VALUES (
      NEW.product_id, NEW.quantity_recived, 0
    );
  END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_after_batch_details_insert` AFTER INSERT ON `batch_details` FOR EACH ROW BEGIN
  DECLARE existing_bill_id INT;

  -- 1. Check if a supplier bill already exists for this batch
  SELECT supplier_bill_id INTO existing_bill_id
  FROM supplierbills
  WHERE batch_id = NEW.batch_id
  LIMIT 1;

  -- 2. If no bill exists, insert one (exclude total_price)
  IF existing_bill_id IS NULL THEN
    INSERT INTO supplierbills (batch_id, supplier_id, date, payment_status, paid_amount)
    SELECT 
      b.batch_id,
      b.supplier_id,
      CURRENT_DATE(),
      'Due',
      0
    FROM batches b
    WHERE b.batch_id = NEW.batch_id;

    SET existing_bill_id = LAST_INSERT_ID();
  END IF;

  -- 3. Insert into supplier_bill_details
  INSERT INTO supplier_bill_details (supplier_bill_id, product_id, quantity)
  VALUES (
    (SELECT supplier_bill_id FROM supplierbills WHERE batch_id = NEW.batch_id LIMIT 1),
    NEW.product_id,
    NEW.quantity_recived
  );

  -- 4. Removed: total_price update (manual entry expected)

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `batches`
--

LOCK TABLES `batches` WRITE;
/*!40000 ALTER TABLE `batches` DISABLE KEYS */;
INSERT INTO `batches` VALUES (6,'Laptop Batch 2025-07',4,'2025-07-01 10:00:00'),(7,'Desktop Batch 2025-07',2,'2025-07-02 11:30:00'),(8,'Accessories Batch 2025-07',3,'2025-07-03 09:15:00'),(9,'mouse-2025',3,'2025-07-05 11:14:45'),(10,'june-25',4,'2025-07-06 13:57:47');
/*!40000 ALTER TABLE `batches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bill_detail_serials`
--

DROP TABLE IF EXISTS `bill_detail_serials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bill_detail_serials` (
  `serial_id` int NOT NULL AUTO_INCREMENT,
  `bill_detail_id` int NOT NULL,
  `product_id` int NOT NULL,
  `serial_number` varchar(100) NOT NULL,
  `status` enum('sold','return') NOT NULL DEFAULT 'sold',
  PRIMARY KEY (`serial_id`),
  UNIQUE KEY `serial_number` (`serial_number`),
  KEY `bill_detail_id` (`bill_detail_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `bill_detail_serials_ibfk_1` FOREIGN KEY (`bill_detail_id`) REFERENCES `customer_bill_details` (`Bill_detail_ID`),
  CONSTRAINT `bill_detail_serials_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bill_detail_serials`
--

LOCK TABLES `bill_detail_serials` WRITE;
/*!40000 ALTER TABLE `bill_detail_serials` DISABLE KEYS */;
INSERT INTO `bill_detail_serials` VALUES (5,62,16,'CNPIX-6001','sold'),(6,63,14,'HPEL840-1001','return'),(7,64,14,'HPEL840-1002','sold'),(8,64,14,'SAMU28-4001','sold'),(9,65,17,'TPAX50-7001','sold'),(13,81,18,'MSO21-8001','return'),(15,85,20,'NVRTX-10001','sold'),(16,87,21,'LGMX3-3001','sold'),(17,87,21,'LGMX3-3002','sold');
/*!40000 ALTER TABLE `bill_detail_serials` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_update_serial_status` AFTER INSERT ON `bill_detail_serials` FOR EACH ROW BEGIN
    -- When a serial is sold, mark it sold in productsserial
    IF NEW.status = 'sold' THEN
        UPDATE productsserial
        SET status = 'sold'
        WHERE sku = NEW.serial_number;

    -- When returned, mark it in_stock again
    ELSEIF NEW.status = 'return' THEN
        UPDATE productsserial
        SET status = 'in_stock'
        WHERE sku = NEW.serial_number;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_sync_serial_status_on_update` AFTER UPDATE ON `bill_detail_serials` FOR EACH ROW BEGIN
    IF NEW.status != OLD.status THEN
        IF NEW.status = 'sold' THEN
            UPDATE productsserial
            SET status = 'sold'
            WHERE sku = NEW.serial_number;
        ELSEIF NEW.status = 'return' THEN
            UPDATE productsserial
            SET status = 'in_stock'
            WHERE sku = NEW.serial_number;
        END IF;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (16,'Accessories'),(15,'Components'),(8,'Desktops'),(7,'Laptops'),(10,'Monitors'),(13,'Networking'),(9,'Peripherals'),(12,'Printers'),(14,'Software'),(11,'Storage');
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
  CONSTRAINT `customerbilldetail_ibfk_1` FOREIGN KEY (`Bill_id`) REFERENCES `customerbills` (`BillID`) ON DELETE CASCADE,
  CONSTRAINT `customerbilldetail_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=92 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_bill_details`
--

LOCK TABLES `customer_bill_details` WRITE;
/*!40000 ALTER TABLE `customer_bill_details` DISABLE KEYS */;
INSERT INTO `customer_bill_details` VALUES (59,46,20,1,0,'bill','1','2025-07-05','2025-07-06'),(60,46,21,2,0,'bill','1','2025-07-05','2025-07-06'),(62,48,16,1,0,'bill','1','2025-07-06','2025-07-07'),(63,49,14,1,0,'bill','15','2025-07-06','2025-07-21'),(64,50,14,2,0,'bill',NULL,'2025-07-06',NULL),(65,50,17,1,0,'bill',NULL,'2025-07-06',NULL),(66,51,23,1,0,'bill','15','2025-07-06','2025-07-21'),(67,52,23,1,0,'bill','15','2025-07-06','2025-07-21'),(68,53,23,1,0,'bill','15','2025-07-06','2025-07-21'),(69,54,23,1,0,'bill','15','2025-07-06','2025-07-21'),(70,55,23,1,0,'bill','15','2025-07-06','2025-07-21'),(71,56,22,1,0,'bill','30','2025-07-06','2025-08-05'),(72,57,22,1,0,'bill','30','2025-07-06','2025-08-05'),(73,58,23,1,0,'bill','15','2025-07-06','2025-07-21'),(80,62,23,1,0,'bill',NULL,'2025-07-06',NULL),(81,62,18,1,0,'bill',NULL,'2025-07-06',NULL),(84,64,23,1,0,'bill',NULL,'2025-07-06',NULL),(85,64,20,1,0,'bill',NULL,'2025-07-06',NULL),(86,65,23,1,0,'bill',NULL,'2025-07-06',NULL),(87,65,21,2,0,'bill',NULL,'2025-07-06',NULL),(88,66,23,1,0,'bill','12','2025-07-06','2025-07-18'),(89,67,23,2,0,'bill',NULL,'2025-07-06',NULL),(90,68,22,1,0,'bill',NULL,'2025-07-06',NULL),(91,69,23,1,0,'bill','15','2025-07-07','2025-07-22');
/*!40000 ALTER TABLE `customer_bill_details` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_auto_set_warranty_till` BEFORE INSERT ON `customer_bill_details` FOR EACH ROW BEGIN
  IF NEW.warranty IS NOT NULL AND NEW.warranty_from IS NOT NULL THEN
    SET NEW.warranty_till = DATE_ADD(NEW.warranty_from, INTERVAL CAST(NEW.warranty AS UNSIGNED) DAY);
  END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_after_customer_sale` AFTER INSERT ON `customer_bill_details` FOR EACH ROW BEGIN
  -- Log the sale
  INSERT INTO inventory_log (
    product_id, change_type, quantity_change, remarks
  ) VALUES (
    NEW.product_id, 'sale', -NEW.quantity,
    CONCAT('Customer bill ID: ', NEW.Bill_id)
  );

  -- Update inventory quantity
  UPDATE inventory
  SET quantity_in_stock = quantity_in_stock - NEW.quantity
  WHERE product_id = NEW.product_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `customer_returns`
--

DROP TABLE IF EXISTS `customer_returns`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer_returns` (
  `return_id` int NOT NULL AUTO_INCREMENT,
  `product_id` int DEFAULT NULL,
  `return_date` date NOT NULL,
  `reason` text,
  `quantity_returned` int NOT NULL,
  `action_taken` enum('Refunded','Replaced','Stock Adjusted') NOT NULL,
  `amount_returned` int DEFAULT NULL,
  `sku` varchar(45) DEFAULT NULL,
  `bill_detail_id` int DEFAULT NULL,
  PRIMARY KEY (`return_id`),
  KEY `product_id` (`product_id`),
  KEY `fk_customer_returns_bill_detail` (`bill_detail_id`),
  CONSTRAINT `customer_returns_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_customer_returns_bill_detail` FOREIGN KEY (`bill_detail_id`) REFERENCES `customer_bill_details` (`Bill_detail_ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_returns`
--

LOCK TABLES `customer_returns` WRITE;
/*!40000 ALTER TABLE `customer_returns` DISABLE KEYS */;
INSERT INTO `customer_returns` VALUES (12,20,'2025-07-06','saxcsacx12',1,'Refunded',12,'NVRTX-10001',59),(13,21,'2025-07-06','hddh',2,'Refunded',NULL,'LGMX3-3001,LGMX3-3002',60),(14,14,'2025-07-06','mood change',1,'Refunded',100,'HPEL840-1001',63),(15,18,'2025-07-07','ihsidhs',1,'Refunded',1000,'MSO21-8001',81);
/*!40000 ALTER TABLE `customer_returns` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_after_customer_return` AFTER INSERT ON `customer_returns` FOR EACH ROW BEGIN
  -- Log the return
  INSERT INTO inventory_log (
    product_id, change_type, quantity_change, remarks
  ) VALUES (
    NEW.product_id, 'return_from_customer', NEW.quantity_returned,
    CONCAT('Return from customer: Bill Detail ID ', NEW.bill_detail_id)
  );

  -- Update inventory quantity
  UPDATE inventory
  SET quantity_in_stock = quantity_in_stock + NEW.quantity_returned
  WHERE product_id = NEW.product_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_after_customer_return_insert` AFTER INSERT ON `customer_returns` FOR EACH ROW BEGIN
  UPDATE inventory
  SET quantity_in_stock = quantity_in_stock + NEW.quantity_returned
  WHERE product_id = NEW.product_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
  `payment_status` enum('Paid','Due') DEFAULT 'Due',
  PRIMARY KEY (`BillID`),
  KEY `CustomerID` (`CustomerID`),
  CONSTRAINT `customerbills_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`customer_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerbills`
--

LOCK TABLES `customerbills` WRITE;
/*!40000 ALTER TABLE `customerbills` DISABLE KEYS */;
INSERT INTO `customerbills` VALUES (13,3,'2025-07-04',18500,18500,'Due'),(14,5,'2025-07-04',17910,17910,'Due'),(15,5,'2025-07-04',15000,15000,'Due'),(16,3,'2025-07-04',95000,95000,'Due'),(17,3,'2025-07-04',95000,95000,'Due'),(18,5,'2025-07-04',15000,15000,'Due'),(19,3,'2025-07-04',15000,15000,'Due'),(20,3,'2025-07-04',95000,95000,'Due'),(21,3,'2025-07-04',18000,18000,'Due'),(22,3,'2025-07-04',3500,3500,'Due'),(23,3,'2025-07-04',3500,3500,'Due'),(24,5,'2025-07-04',18000,18000,'Due'),(25,5,'2025-07-04',113000,113000,'Due'),(26,6,'2025-07-04',121000,121000,'Due'),(27,6,'2025-07-04',18000,18000,'Due'),(28,3,'2025-07-04',95000,95000,'Due'),(29,3,'2025-07-04',131000,131000,'Due'),(30,7,'2025-07-04',150000,150000,'Due'),(31,7,'2025-07-04',235000,235000,'Due'),(32,7,'2025-07-04',235000,235000,'Due'),(33,7,'2025-07-04',150000,150000,'Due'),(34,6,'2025-07-04',83000,83000,'Due'),(35,3,'2025-07-04',235000,235000,'Due'),(36,7,'2025-07-04',3500,3500,'Due'),(37,7,'2025-07-04',3500,3500,'Due'),(38,8,'2025-07-04',67500,67500,'Due'),(39,8,'2025-07-04',79000,79000,'Due'),(40,8,'2025-07-04',8000,8000,'Due'),(41,8,'2025-07-04',8000,8000,'Due'),(42,6,'2025-07-04',18000,18000,'Due'),(43,7,'2025-07-05',130000,130000,'Due'),(44,6,'2025-07-05',170000,170000,'Due'),(45,5,'2025-07-05',28000,28000,'Due'),(46,7,'2025-07-05',71000,71000,'Due'),(48,6,'2025-07-06',2500,2500,'Due'),(49,6,'2025-07-06',85000,85000,'Due'),(50,9,'2025-07-06',202000,100000,'Due'),(51,7,'2025-07-06',190000,190000,'Due'),(52,6,'2025-07-06',95000,95000,'Due'),(53,10,'2025-07-06',190000,190000,'Due'),(54,7,'2025-07-06',190000,190000,'Due'),(55,7,'2025-07-06',190000,190000,'Due'),(56,8,'2025-07-06',7000,7000,'Due'),(57,8,'2025-07-06',7000,7000,'Due'),(58,3,'2025-07-06',95000,95000,'Due'),(62,8,'2025-07-06',159000,159000,'Paid'),(64,8,'2025-07-06',110000,110000,'Paid'),(65,6,'2025-07-06',246000,246000,'Paid'),(66,7,'2025-07-06',190000,190000,'Paid'),(67,7,'2025-07-06',190000,190000,'Paid'),(68,4,'2025-07-06',2000,900,'Due'),(69,7,'2025-07-07',190000,190000,'Paid');
/*!40000 ALTER TABLE `customerbills` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `before_insert_customerbills` BEFORE INSERT ON `customerbills` FOR EACH ROW BEGIN
    IF NEW.total_price = NEW.paid_amount THEN
        SET NEW.payment_status = 'Paid';
    ELSE
        SET NEW.payment_status = 'Due';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `before_update_customerbills` BEFORE UPDATE ON `customerbills` FOR EACH ROW BEGIN
    IF NEW.total_price = NEW.paid_amount THEN
        SET NEW.payment_status = 'Paid';
    ELSE
        SET NEW.payment_status = 'Due';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `customerpricerecord`
--

DROP TABLE IF EXISTS `customerpricerecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customerpricerecord` (
  `record_id` int NOT NULL AUTO_INCREMENT,
  `customer_id` int NOT NULL,
  `BillID` int NOT NULL,
  `date` date NOT NULL,
  `payment` decimal(10,2) NOT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`record_id`),
  KEY `customer_id` (`customer_id`),
  KEY `BillID` (`BillID`),
  CONSTRAINT `customerpricerecord_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`),
  CONSTRAINT `customerpricerecord_ibfk_2` FOREIGN KEY (`BillID`) REFERENCES `customerbills` (`BillID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `customerpricerecord_chk_1` CHECK ((`payment` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerpricerecord`
--

LOCK TABLES `customerpricerecord` WRITE;
/*!40000 ALTER TABLE `customerpricerecord` DISABLE KEYS */;
INSERT INTO `customerpricerecord` VALUES (1,3,58,'2025-07-06',95000.00,NULL),(5,8,62,'2025-07-06',159000.00,NULL),(7,8,64,'2025-07-06',110000.00,NULL),(8,6,65,'2025-07-06',246000.00,NULL),(9,7,66,'2025-07-06',190000.00,NULL),(10,7,67,'2025-07-06',190000.00,NULL),(11,4,68,'2025-07-06',900.00,NULL),(12,7,69,'2025-07-07',190000.00,NULL);
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
  UNIQUE KEY `first_name` (`first_name`,`last_name`),
  KEY `idx_customers_type` (`type`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (2,'Regular','Ali','Khan','03001112233','ali.khan@email.com','10 Garden Town, Lahore'),(3,'Walk-in','Sana','Ahmed','03004445566',NULL,'22 Model Town, Karachi'),(4,'Regular','Usman','Malik','03007778899','usman.malik@email.com','35 Satellite Town, Rawalpindi'),(5,'Walk-in','z\r\nzain','',NULL,NULL,NULL),(6,'Walk-in','ahad\r\nzain','',NULL,NULL,NULL),(7,'Walk-in','ahad','ilyas',NULL,NULL,NULL),(8,'Walk-in','avdd','',NULL,NULL,NULL),(9,'Regular','abdul','ahad','03027457206','iihaihha','faislabad'),(10,'Walk-in','','',NULL,NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (24,14,85000,-7),(25,15,65000,-7),(26,16,2500,10),(27,17,32000,1),(28,18,8000,6),(29,19,18000,-5),(30,20,15000,0),(31,21,28000,4),(32,22,3500,-1),(33,23,95000,-18);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory_log`
--

DROP TABLE IF EXISTS `inventory_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory_log` (
  `log_id` int NOT NULL AUTO_INCREMENT,
  `product_id` int NOT NULL,
  `change_type` enum('purchase','sale','return_from_customer','return_to_supplier','manual_adjustment') NOT NULL,
  `quantity_change` int NOT NULL,
  `log_date` datetime DEFAULT CURRENT_TIMESTAMP,
  `remarks` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`log_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `inventory_log_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=97 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory_log`
--

LOCK TABLES `inventory_log` WRITE;
/*!40000 ALTER TABLE `inventory_log` DISABLE KEYS */;
INSERT INTO `inventory_log` VALUES (13,20,'sale',-1,'2025-07-04 16:04:09','Customer bill ID: 13'),(14,22,'sale',-1,'2025-07-04 16:04:09','Customer bill ID: 13'),(15,19,'sale',-1,'2025-07-04 16:17:09','Customer bill ID: 14'),(16,20,'sale',-1,'2025-07-04 16:40:41','Customer bill ID: 15'),(17,23,'sale',-1,'2025-07-04 16:55:53','Customer bill ID: 16'),(18,23,'sale',-1,'2025-07-04 16:56:11','Customer bill ID: 17'),(19,20,'sale',-1,'2025-07-04 17:01:46','Customer bill ID: 18'),(20,20,'sale',-1,'2025-07-04 17:06:37','Customer bill ID: 19'),(21,23,'sale',-1,'2025-07-04 17:11:38','Customer bill ID: 20'),(22,19,'sale',-1,'2025-07-04 17:14:09','Customer bill ID: 21'),(23,22,'sale',-1,'2025-07-04 17:20:53','Customer bill ID: 22'),(24,22,'sale',-1,'2025-07-04 17:21:03','Customer bill ID: 23'),(25,19,'sale',-1,'2025-07-04 17:22:54','Customer bill ID: 24'),(26,19,'sale',-1,'2025-07-04 18:04:15','Customer bill ID: 25'),(27,23,'sale',-1,'2025-07-04 18:04:15','Customer bill ID: 25'),(28,15,'sale',-1,'2025-07-04 18:08:56','Customer bill ID: 26'),(29,21,'sale',-2,'2025-07-04 18:08:56','Customer bill ID: 26'),(30,19,'sale',-1,'2025-07-04 18:51:52','Customer bill ID: 27'),(31,23,'sale',-1,'2025-07-04 19:00:05','Customer bill ID: 28'),(32,23,'sale',-1,'2025-07-04 19:00:58','Customer bill ID: 29'),(33,18,'sale',-1,'2025-07-04 19:00:58','Customer bill ID: 29'),(34,21,'sale',-1,'2025-07-04 19:00:58','Customer bill ID: 29'),(35,15,'sale',-1,'2025-07-04 19:14:50','Customer bill ID: 30'),(36,14,'sale',-1,'2025-07-04 19:14:50','Customer bill ID: 30'),(37,15,'sale',-1,'2025-07-04 19:56:28','Customer bill ID: 31'),(38,14,'sale',-2,'2025-07-04 19:56:28','Customer bill ID: 31'),(39,15,'sale',-1,'2025-07-04 20:04:12','Customer bill ID: 32'),(40,14,'sale',-2,'2025-07-04 20:04:12','Customer bill ID: 32'),(41,14,'sale',-1,'2025-07-04 20:05:48','Customer bill ID: 33'),(42,15,'sale',-1,'2025-07-04 20:05:48','Customer bill ID: 33'),(43,19,'sale',-1,'2025-07-04 20:11:32','Customer bill ID: 34'),(44,15,'sale',-1,'2025-07-04 20:11:32','Customer bill ID: 34'),(45,15,'sale',-1,'2025-07-04 20:17:29','Customer bill ID: 35'),(46,14,'sale',-2,'2025-07-04 20:17:29','Customer bill ID: 35'),(47,22,'sale',-1,'2025-07-04 20:41:30','Customer bill ID: 36'),(48,22,'sale',-1,'2025-07-04 20:43:50','Customer bill ID: 37'),(49,16,'sale',-1,'2025-07-04 20:52:14','Customer bill ID: 38'),(50,15,'sale',-1,'2025-07-04 20:52:14','Customer bill ID: 38'),(51,17,'sale',-2,'2025-07-04 20:55:19','Customer bill ID: 39'),(52,20,'sale',-1,'2025-07-04 20:55:19','Customer bill ID: 39'),(53,18,'sale',-1,'2025-07-04 21:01:47','Customer bill ID: 40'),(54,18,'sale',-1,'2025-07-04 21:47:13','Customer bill ID: 41'),(55,19,'sale',-1,'2025-07-04 21:51:33','Customer bill ID: 42'),(56,15,'sale',-2,'2025-07-05 06:08:13','Customer bill ID: 43'),(57,14,'sale',-2,'2025-07-05 06:11:25','Customer bill ID: 44'),(58,21,'sale',-1,'2025-07-05 06:16:36','Customer bill ID: 45'),(59,20,'sale',-1,'2025-07-05 22:53:06','Customer bill ID: 46'),(60,21,'sale',-2,'2025-07-05 22:53:06','Customer bill ID: 46'),(62,16,'sale',-1,'2025-07-06 05:35:32','Customer bill ID: 48'),(64,20,'return_from_customer',1,'2025-07-06 06:59:52','Return from customer: Bill Detail ID 59'),(65,21,'return_from_customer',2,'2025-07-06 07:31:55','Return from customer: Bill Detail ID 60'),(66,14,'sale',-1,'2025-07-06 10:06:50','Customer bill ID: 49'),(67,14,'return_from_customer',1,'2025-07-06 10:11:15','Return from customer: Bill Detail ID 63'),(68,14,'sale',-2,'2025-07-06 10:21:14','Customer bill ID: 50'),(69,17,'sale',-1,'2025-07-06 10:21:14','Customer bill ID: 50'),(70,23,'sale',-1,'2025-07-06 14:57:14','Customer bill ID: 51'),(71,23,'sale',-1,'2025-07-06 14:59:46','Customer bill ID: 52'),(72,23,'sale',-1,'2025-07-06 15:00:59','Customer bill ID: 53'),(73,23,'sale',-1,'2025-07-06 15:48:00','Customer bill ID: 54'),(74,23,'sale',-1,'2025-07-06 15:48:14','Customer bill ID: 55'),(75,22,'sale',-1,'2025-07-06 15:50:35','Customer bill ID: 56'),(76,22,'sale',-1,'2025-07-06 15:50:42','Customer bill ID: 57'),(77,23,'sale',-1,'2025-07-06 15:57:48','Customer bill ID: 58'),(84,23,'sale',-1,'2025-07-06 18:47:41','Customer bill ID: 62'),(85,18,'sale',-1,'2025-07-06 18:47:41','Customer bill ID: 62'),(88,23,'sale',-1,'2025-07-06 18:54:37','Customer bill ID: 64'),(89,20,'sale',-1,'2025-07-06 18:54:38','Customer bill ID: 64'),(90,23,'sale',-1,'2025-07-06 19:01:25','Customer bill ID: 65'),(91,21,'sale',-2,'2025-07-06 19:01:25','Customer bill ID: 65'),(92,23,'sale',-1,'2025-07-06 22:51:18','Customer bill ID: 66'),(93,23,'sale',-2,'2025-07-06 22:53:51','Customer bill ID: 67'),(94,22,'sale',-1,'2025-07-06 23:12:50','Customer bill ID: 68'),(95,23,'sale',-1,'2025-07-07 05:58:14','Customer bill ID: 69'),(96,18,'return_from_customer',1,'2025-07-07 05:59:46','Return from customer: Bill Detail ID 81');
/*!40000 ALTER TABLE `inventory_log` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (14,'HP EliteBook 840','14\" Business Laptop, Core i7, 16GB RAM',16),(15,'Dell OptiPlex 3080','Compact Desktop, Core i5, 8GB RAM',15),(16,'Logitech MX Master 3','Wireless Productivity Mouse',14),(17,'Samsung U28R550','28\" 4K UHD Monitor',13),(18,'WD My Passport 2TB','Portable External Hard Drive',12),(19,'Canon PIXMA TR4520','All-in-One Wireless Printer',11),(20,'TP-Link Archer AX50','WiFi 6 Router',7),(21,'Microsoft Office 2021','Home & Student Edition',8),(22,'Corsair K95 RGB','Mechanical Gaming Keyboard',9),(23,'NVIDIA GeForce RTX 3080','10GB GDDR6X Graphics Card',10);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_after_product_insert` AFTER INSERT ON `products` FOR EACH ROW BEGIN
    INSERT INTO inventory (product_id, quantity_in_stock, sale_price)
    VALUES (NEW.product_id, 0, 0);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `productsserial`
--

DROP TABLE IF EXISTS `productsserial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productsserial` (
  `sku` varchar(200) NOT NULL,
  `product_id` int NOT NULL,
  `status` enum('in_stock','sold','returned') NOT NULL DEFAULT 'in_stock',
  PRIMARY KEY (`sku`),
  KEY `fk_serial_1_idx` (`product_id`),
  CONSTRAINT `fk_serial_1` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productsserial`
--

LOCK TABLES `productsserial` WRITE;
/*!40000 ALTER TABLE `productsserial` DISABLE KEYS */;
INSERT INTO `productsserial` VALUES ('CNPIX-6001',16,'sold'),('CRK95-9001',19,'sold'),('DLOP3080-2001',15,'in_stock'),('HPEL840-1001',14,'in_stock'),('HPEL840-1002',14,'sold'),('LGMX3-3001',21,'sold'),('LGMX3-3002',21,'sold'),('MSO21-8001',18,'in_stock'),('NVRTX-10001',20,'sold'),('SAMU28-4001',14,'sold'),('TPAX50-7001',17,'sold'),('WDPP2T-5001',15,'sold');
/*!40000 ALTER TABLE `productsserial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier_bill_details`
--

DROP TABLE IF EXISTS `supplier_bill_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplier_bill_details` (
  `s_Bill_detail_ID` int NOT NULL AUTO_INCREMENT,
  `supplier_Bill_ID` int NOT NULL,
  `product_id` int DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  PRIMARY KEY (`s_Bill_detail_ID`),
  KEY `supplierbilldetail_ibfk_2` (`product_id`),
  KEY `supplierbilldetail_ibfk_1` (`supplier_Bill_ID`),
  CONSTRAINT `supplierbilldetail_ibfk_1` FOREIGN KEY (`supplier_Bill_ID`) REFERENCES `supplierbills` (`supplier_Bill_ID`) ON UPDATE CASCADE,
  CONSTRAINT `supplierbilldetail_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier_bill_details`
--

LOCK TABLES `supplier_bill_details` WRITE;
/*!40000 ALTER TABLE `supplier_bill_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplier_bill_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier_returns`
--

DROP TABLE IF EXISTS `supplier_returns`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplier_returns` (
  `supplier_return_id` int NOT NULL AUTO_INCREMENT,
  `supplier_bill_detail_id` int NOT NULL,
  `product_id` int DEFAULT NULL,
  `return_date` date NOT NULL,
  `reason` text,
  `quantity_returned` int NOT NULL,
  `action_taken` enum('Refunded','Replaced') NOT NULL,
  `amount_refunded` int DEFAULT NULL,
  PRIMARY KEY (`supplier_return_id`),
  KEY `supplier_bill_detail_id` (`supplier_bill_detail_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `supplier_returns_ibfk_1` FOREIGN KEY (`supplier_bill_detail_id`) REFERENCES `supplier_bill_details` (`s_Bill_detail_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `supplier_returns_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier_returns`
--

LOCK TABLES `supplier_returns` WRITE;
/*!40000 ALTER TABLE `supplier_returns` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplier_returns` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_after_supplier_return` AFTER INSERT ON `supplier_returns` FOR EACH ROW BEGIN
  -- Log the return
  INSERT INTO inventory_log (
    product_id, change_type, quantity_change, reference_id, remarks
  ) VALUES (
    NEW.product_id, 'return_to_supplier', -NEW.quantity_returned, NEW.supplier_bill_detail_id,
    CONCAT('Return to supplier ID: ', NEW.supplier_bill_detail_id)
  );

  -- Update inventory quantity
  UPDATE inventory
  SET quantity_in_stock = quantity_in_stock - NEW.quantity_returned
  WHERE product_id = NEW.product_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
  `paid_amount` int DEFAULT '0',
  `payment_status` enum('Paid','Due') DEFAULT 'Due',
  PRIMARY KEY (`supplier_Bill_ID`),
  KEY `supplier_id` (`supplier_id`),
  KEY `fk_sb_2` (`batch_id`),
  CONSTRAINT `fk_sb_2` FOREIGN KEY (`batch_id`) REFERENCES `batches` (`batch_id`),
  CONSTRAINT `supplierbills_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `chk_paid_vs_total` CHECK ((`paid_amount` <= `total_price`))
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplierbills`
--

LOCK TABLES `supplierbills` WRITE;
/*!40000 ALTER TABLE `supplierbills` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplierbills` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_set_status_paid` AFTER UPDATE ON `supplierbills` FOR EACH ROW BEGIN
  IF NEW.paid_amount = NEW.total_price THEN
    UPDATE supplierbills
    SET status = 'Paid'
    WHERE supplier_bill_id = NEW.supplier_bill_id;
  END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `supplierpricerecord`
--

DROP TABLE IF EXISTS `supplierpricerecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplierpricerecord` (
  `supplier_record_id` int NOT NULL AUTO_INCREMENT,
  `supplier_id` int NOT NULL,
  `supplier_Bill_ID` int NOT NULL,
  `date` date NOT NULL,
  `payment` decimal(10,2) NOT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`supplier_record_id`),
  KEY `supplier_id` (`supplier_id`),
  KEY `supplier_Bill_ID` (`supplier_Bill_ID`),
  CONSTRAINT `supplierpricerecord_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`),
  CONSTRAINT `supplierpricerecord_ibfk_2` FOREIGN KEY (`supplier_Bill_ID`) REFERENCES `supplierbills` (`supplier_Bill_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `supplierpricerecord_chk_1` CHECK ((`payment` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplierpricerecord`
--

LOCK TABLES `supplierpricerecord` WRITE;
/*!40000 ALTER TABLE `supplierpricerecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplierpricerecord` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_update_supplierbill_paidamount` AFTER INSERT ON `supplierpricerecord` FOR EACH ROW BEGIN
  UPDATE supplierbills
  SET paid_amount = paid_amount + NEW.payment
  WHERE supplier_bill_id = NEW.supplier_bill_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (2,'Tech Distributors','03001234567','sales@techdist.com','123 Main St, Lahore'),(3,'Computer World','03007654321','info@compworld.com','456 Mall Rd, Karachi'),(4,'Electro Gadgets','03009876543','contact@electrogad.com','789 Center Ave, Islamabad');
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

-- Dump completed on 2025-07-07  7:01:22
