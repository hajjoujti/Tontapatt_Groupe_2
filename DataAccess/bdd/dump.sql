-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: localhost    Database: tontapatt_bdd
-- ------------------------------------------------------
-- Server version	8.0.25

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
-- Table structure for table `anomalie`
--

DROP TABLE IF EXISTS `anomalie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `anomalie` (
  `id_anomalie` int NOT NULL AUTO_INCREMENT,
  `id_demande` int NOT NULL,
  `id_utilisateur_client` int DEFAULT NULL,
  `id_utilisateur_eleveur` int DEFAULT NULL,
  `id_type_anomalie` int NOT NULL,
  `description_anomalie` varchar(254) DEFAULT NULL,
  `date_declenchement_anomalie` datetime DEFAULT NULL,
  `date_fin_anomalie` datetime DEFAULT NULL,
  PRIMARY KEY (`id_anomalie`),
  KEY `FK_ANOMALIE_DEMANDERE_DEMANDED` (`id_demande`),
  KEY `FK_ANOMALIE_IDCLIENT_UTILISAT` (`id_utilisateur_client`),
  KEY `FK_ANOMALIE_IDELEVEUR_UTILISAT` (`id_utilisateur_eleveur`),
  KEY `FK_ANOMALIE_TYPEANOMA_TYPEANOM` (`id_type_anomalie`),
  CONSTRAINT `FK_ANOMALIE_DEMANDERE_DEMANDED` FOREIGN KEY (`id_demande`) REFERENCES `demandedereservation` (`id_demande`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ANOMALIE_IDCLIENT_UTILISAT` FOREIGN KEY (`id_utilisateur_client`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ANOMALIE_IDELEVEUR_UTILISAT` FOREIGN KEY (`id_utilisateur_eleveur`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_ANOMALIE_TYPEANOMA_TYPEANOM` FOREIGN KEY (`id_type_anomalie`) REFERENCES `typeanomalie` (`id_type_anomalie`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `anomalie`
--

LOCK TABLES `anomalie` WRITE;
/*!40000 ALTER TABLE `anomalie` DISABLE KEYS */;
/*!40000 ALTER TABLE `anomalie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `composition`
--

DROP TABLE IF EXISTS `composition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `composition` (
  `id_type_vegetation` int NOT NULL,
  `id_terrain` int NOT NULL,
  `pourcentage_vegetation` int DEFAULT NULL,
  PRIMARY KEY (`id_type_vegetation`,`id_terrain`),
  KEY `FK_COMPOSIT_COMPOSITI_TERRAIN` (`id_terrain`),
  CONSTRAINT `FK_COMPOSIT_COMPOSITI_TERRAIN` FOREIGN KEY (`id_terrain`) REFERENCES `terrain` (`id_terrain`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_COMPOSIT_COMPOSITI_TYPEVEGE` FOREIGN KEY (`id_type_vegetation`) REFERENCES `typevegetation` (`id_type_vegetation`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `composition`
--

LOCK TABLES `composition` WRITE;
/*!40000 ALTER TABLE `composition` DISABLE KEYS */;
/*!40000 ALTER TABLE `composition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compositionterrain`
--

DROP TABLE IF EXISTS `compositionterrain`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `compositionterrain` (
  `id_composition_terrain` int NOT NULL AUTO_INCREMENT,
  `composition_terrain` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_composition_terrain`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compositionterrain`
--

LOCK TABLES `compositionterrain` WRITE;
/*!40000 ALTER TABLE `compositionterrain` DISABLE KEYS */;
/*!40000 ALTER TABLE `compositionterrain` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compositionterrainfavori`
--

DROP TABLE IF EXISTS `compositionterrainfavori`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `compositionterrainfavori` (
  `id_composition_terrain` int NOT NULL,
  `id_espece_animal` int NOT NULL,
  PRIMARY KEY (`id_composition_terrain`,`id_espece_animal`),
  KEY `FK_COMPOSIT_COMPOSITI_ESPECE` (`id_espece_animal`),
  CONSTRAINT `FK_COMPOSIT_COMPOSITI_COMPOSIT` FOREIGN KEY (`id_composition_terrain`) REFERENCES `compositionterrain` (`id_composition_terrain`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_COMPOSIT_COMPOSITI_ESPECE` FOREIGN KEY (`id_espece_animal`) REFERENCES `espece` (`id_espece_animal`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compositionterrainfavori`
--

LOCK TABLES `compositionterrainfavori` WRITE;
/*!40000 ALTER TABLE `compositionterrainfavori` DISABLE KEYS */;
/*!40000 ALTER TABLE `compositionterrainfavori` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `demandedereservation`
--

DROP TABLE IF EXISTS `demandedereservation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `demandedereservation` (
  `id_demande` int NOT NULL AUTO_INCREMENT,
  `id_raison_annul_prem` int DEFAULT NULL,
  `id_terrain` int NOT NULL,
  `id_raison_annul` int DEFAULT NULL,
  `id_motif_refus` int DEFAULT NULL,
  `id_moyen_paiement` int DEFAULT NULL,
  `id_offre` int NOT NULL,
  `date_debut_demande` datetime NOT NULL,
  `date_fin_demande` datetime NOT NULL,
  `cout_demande` decimal(8,0) DEFAULT NULL,
  `date_acceptaion_demande` datetime DEFAULT NULL,
  `date_annulation_demande` datetime DEFAULT NULL,
  `date_creation_demande` datetime DEFAULT NULL,
  `date_installation_troupeau` datetime DEFAULT NULL,
  `date_annulation_prematuree` datetime DEFAULT NULL,
  `numero_reservation` int NOT NULL,
  `date_refus_demande` datetime DEFAULT NULL,
  PRIMARY KEY (`id_demande`),
  UNIQUE KEY `numero_reservation_UNIQUE` (`numero_reservation`),
  KEY `FK_DEMANDED_MOYENPAIE_MOYENPAI` (`id_moyen_paiement`),
  KEY `FK_DEMANDED_OFFREDETO_OFFREDET` (`id_offre`),
  KEY `FK_DEMANDED_RAISONANNULATION_RAISONAN` (`id_raison_annul`),
  KEY `FK_DEMANDED_RAISONANNULATIONPREMATUREE_RAISONAN` (`id_raison_annul_prem`),
  KEY `FK_DEMANDED_RAISONREF_RAISONRE` (`id_motif_refus`),
  KEY `FK_DEMANDED_TERRAIN_TERRAIN` (`id_terrain`),
  CONSTRAINT `FK_DEMANDED_MOYENPAIE_MOYENPAI` FOREIGN KEY (`id_moyen_paiement`) REFERENCES `moyenpaiement` (`id_moyen_paiement`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_DEMANDED_OFFREDETO_OFFREDET` FOREIGN KEY (`id_offre`) REFERENCES `offredetonte` (`id_offre`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_DEMANDED_RAISONANNULATION_RAISONAN` FOREIGN KEY (`id_raison_annul`) REFERENCES `raisonannulationdemande` (`id_raison_annul`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_DEMANDED_RAISONANNULATIONPREMATUREE_RAISONAN` FOREIGN KEY (`id_raison_annul_prem`) REFERENCES `raisonannulationprematuree` (`id_raison_annul_prem`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_DEMANDED_RAISONREF_RAISONRE` FOREIGN KEY (`id_motif_refus`) REFERENCES `raisonrefusdemande` (`id_motif_refus`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_DEMANDED_TERRAIN_TERRAIN` FOREIGN KEY (`id_terrain`) REFERENCES `terrain` (`id_terrain`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `demandedereservation`
--

LOCK TABLES `demandedereservation` WRITE;
/*!40000 ALTER TABLE `demandedereservation` DISABLE KEYS */;
/*!40000 ALTER TABLE `demandedereservation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `espece`
--

DROP TABLE IF EXISTS `espece`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `espece` (
  `id_espece_animal` int NOT NULL AUTO_INCREMENT,
  `espece_animal` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_espece_animal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `espece`
--

LOCK TABLES `espece` WRITE;
/*!40000 ALTER TABLE `espece` DISABLE KEYS */;
/*!40000 ALTER TABLE `espece` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evaluationprestation`
--

DROP TABLE IF EXISTS `evaluationprestation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evaluationprestation` (
  `id_eval_prestation` int NOT NULL AUTO_INCREMENT,
  `id_utilisateur_client` int DEFAULT NULL,
  `id_demande` int NOT NULL,
  `id_utilisateur_eleveur` int DEFAULT NULL,
  `note_prestation` int DEFAULT NULL,
  `remarque_eval` int DEFAULT NULL,
  PRIMARY KEY (`id_eval_prestation`),
  KEY `FK_EVALUATI_IDCLIENT_UTILISAT` (`id_utilisateur_client`),
  KEY `FK_EVALUATI_IDELEVEUR_UTILISAT` (`id_utilisateur_eleveur`),
  KEY `FK_EVALUATI_DEMANDEDE_DEMANDED` (`id_demande`),
  CONSTRAINT `FK_EVALUATI_DEMANDEDE_DEMANDED` FOREIGN KEY (`id_demande`) REFERENCES `demandedereservation` (`id_demande`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_EVALUATI_IDCLIENT_UTILISAT` FOREIGN KEY (`id_utilisateur_client`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_EVALUATI_IDELEVEUR_UTILISAT` FOREIGN KEY (`id_utilisateur_eleveur`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evaluationprestation`
--

LOCK TABLES `evaluationprestation` WRITE;
/*!40000 ALTER TABLE `evaluationprestation` DISABLE KEYS */;
/*!40000 ALTER TABLE `evaluationprestation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hauteurherbe`
--

DROP TABLE IF EXISTS `hauteurherbe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hauteurherbe` (
  `id_hauteur_herbe` int NOT NULL AUTO_INCREMENT,
  `hauteur_herbe` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_hauteur_herbe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hauteurherbe`
--

LOCK TABLES `hauteurherbe` WRITE;
/*!40000 ALTER TABLE `hauteurherbe` DISABLE KEYS */;
/*!40000 ALTER TABLE `hauteurherbe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hauteurherbefavori`
--

DROP TABLE IF EXISTS `hauteurherbefavori`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hauteurherbefavori` (
  `id_hauteur_herbe` int NOT NULL,
  `id_espece_animal` int NOT NULL,
  PRIMARY KEY (`id_hauteur_herbe`,`id_espece_animal`),
  KEY `FK_HAUTEURH_HAUTEURHE_ESPECE` (`id_espece_animal`),
  CONSTRAINT `FK_HAUTEURH_HAUTEURHE_ESPECE` FOREIGN KEY (`id_espece_animal`) REFERENCES `espece` (`id_espece_animal`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_HAUTEURH_HAUTEURHE_HAUTEURH` FOREIGN KEY (`id_hauteur_herbe`) REFERENCES `hauteurherbe` (`id_hauteur_herbe`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hauteurherbefavori`
--

LOCK TABLES `hauteurherbefavori` WRITE;
/*!40000 ALTER TABLE `hauteurherbefavori` DISABLE KEYS */;
/*!40000 ALTER TABLE `hauteurherbefavori` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `humiditeterrain`
--

DROP TABLE IF EXISTS `humiditeterrain`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `humiditeterrain` (
  `id_humidite_terraine` int NOT NULL AUTO_INCREMENT,
  `humidite_terrain` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_humidite_terraine`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `humiditeterrain`
--

LOCK TABLES `humiditeterrain` WRITE;
/*!40000 ALTER TABLE `humiditeterrain` DISABLE KEYS */;
/*!40000 ALTER TABLE `humiditeterrain` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `humiditeterrainfavori`
--

DROP TABLE IF EXISTS `humiditeterrainfavori`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `humiditeterrainfavori` (
  `id_humidite_terraine` int NOT NULL,
  `id_espece_animal` int NOT NULL,
  PRIMARY KEY (`id_humidite_terraine`,`id_espece_animal`),
  KEY `FK_HUMIDITE_HUMIDITET_ESPECE` (`id_espece_animal`),
  CONSTRAINT `FK_HUMIDITE_HUMIDITET_ESPECE` FOREIGN KEY (`id_espece_animal`) REFERENCES `espece` (`id_espece_animal`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_HUMIDITE_HUMIDITET_HUMIDITE` FOREIGN KEY (`id_humidite_terraine`) REFERENCES `humiditeterrain` (`id_humidite_terraine`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `humiditeterrainfavori`
--

LOCK TABLES `humiditeterrainfavori` WRITE;
/*!40000 ALTER TABLE `humiditeterrainfavori` DISABLE KEYS */;
/*!40000 ALTER TABLE `humiditeterrainfavori` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `moyenpaiement`
--

DROP TABLE IF EXISTS `moyenpaiement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `moyenpaiement` (
  `id_moyen_paiement` int NOT NULL AUTO_INCREMENT,
  `type_moyen_paiement` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_moyen_paiement`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moyenpaiement`
--

LOCK TABLES `moyenpaiement` WRITE;
/*!40000 ALTER TABLE `moyenpaiement` DISABLE KEYS */;
/*!40000 ALTER TABLE `moyenpaiement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `offredetonte`
--

DROP TABLE IF EXISTS `offredetonte`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `offredetonte` (
  `id_offre` int NOT NULL AUTO_INCREMENT,
  `id_race_animal` int NOT NULL,
  `id_annulation_offre` int DEFAULT NULL,
  `id_utilisateur` int NOT NULL,
  `id_villeCP` int NOT NULL,
  `nom_offre` varchar(254) DEFAULT NULL,
  `adresse_troupeau` varchar(254) DEFAULT NULL,
  `date_debut_offre` datetime DEFAULT NULL,
  `date_fin_offre` datetime DEFAULT NULL,
  `date_creation_offre` datetime DEFAULT NULL,
  `Description_offre` varchar(254) DEFAULT NULL,
  `distance_maximale` int DEFAULT NULL,
  `cout_anilmal_par_jour` decimal(8,0) DEFAULT NULL,
  `date_annulation_offre` datetime DEFAULT NULL,
  `nombre_animaux` int DEFAULT NULL,
  PRIMARY KEY (`id_offre`),
  KEY `FK_OFFREDET_RACEANIMA_RACEANIM` (`id_race_animal`),
  KEY `FK_OFFREDET_RAISONANN_RAISONAN` (`id_annulation_offre`),
  KEY `FK_OFFREDET_UTILISATE_UTILISAT` (`id_utilisateur`),
  KEY `FK_OFFREDET_VILLECP_VILLECP` (`id_villeCP`),
  CONSTRAINT `FK_OFFREDET_RACEANIMA_RACEANIM` FOREIGN KEY (`id_race_animal`) REFERENCES `raceanimal` (`id_race_animal`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_OFFREDET_RAISONANN_RAISONAN` FOREIGN KEY (`id_annulation_offre`) REFERENCES `raisonannulationoffre` (`id_annulation_offre`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_OFFREDET_UTILISATE_UTILISAT` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_OFFREDET_VILLECP_VILLECP` FOREIGN KEY (`id_villeCP`) REFERENCES `villecp` (`id_villeCP`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `offredetonte`
--

LOCK TABLES `offredetonte` WRITE;
/*!40000 ALTER TABLE `offredetonte` DISABLE KEYS */;
/*!40000 ALTER TABLE `offredetonte` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `penteterrain`
--

DROP TABLE IF EXISTS `penteterrain`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `penteterrain` (
  `id_pente_terrain` int NOT NULL AUTO_INCREMENT,
  `pente_terrain` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_pente_terrain`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `penteterrain`
--

LOCK TABLES `penteterrain` WRITE;
/*!40000 ALTER TABLE `penteterrain` DISABLE KEYS */;
/*!40000 ALTER TABLE `penteterrain` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `penteterrainfavori`
--

DROP TABLE IF EXISTS `penteterrainfavori`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `penteterrainfavori` (
  `id_pente_terrain` int NOT NULL,
  `id_espece_animal` int NOT NULL,
  PRIMARY KEY (`id_pente_terrain`,`id_espece_animal`),
  KEY `FK_PENTETER_PENTETERR_ESPECE` (`id_espece_animal`),
  CONSTRAINT `FK_PENTETER_PENTETERR_ESPECE` FOREIGN KEY (`id_espece_animal`) REFERENCES `espece` (`id_espece_animal`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_PENTETER_PENTETERR_PENTETER` FOREIGN KEY (`id_pente_terrain`) REFERENCES `penteterrain` (`id_pente_terrain`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `penteterrainfavori`
--

LOCK TABLES `penteterrainfavori` WRITE;
/*!40000 ALTER TABLE `penteterrainfavori` DISABLE KEYS */;
/*!40000 ALTER TABLE `penteterrainfavori` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pointagejournalier`
--

DROP TABLE IF EXISTS `pointagejournalier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pointagejournalier` (
  `id_pointage` int NOT NULL AUTO_INCREMENT,
  `id_demande` int NOT NULL,
  `heure_pointage` datetime DEFAULT NULL,
  `heure_prevu` datetime DEFAULT NULL,
  PRIMARY KEY (`id_pointage`),
  KEY `FK_POINTAGE_DEMANDEDE_DEMANDED` (`id_demande`),
  CONSTRAINT `FK_POINTAGE_DEMANDEDE_DEMANDED` FOREIGN KEY (`id_demande`) REFERENCES `demandedereservation` (`id_demande`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pointagejournalier`
--

LOCK TABLES `pointagejournalier` WRITE;
/*!40000 ALTER TABLE `pointagejournalier` DISABLE KEYS */;
/*!40000 ALTER TABLE `pointagejournalier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `raceanimal`
--

DROP TABLE IF EXISTS `raceanimal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `raceanimal` (
  `id_race_animal` int NOT NULL AUTO_INCREMENT,
  `id_espece_animal` int NOT NULL,
  `race_animal` int DEFAULT NULL,
  PRIMARY KEY (`id_race_animal`),
  KEY `FK_RACEANIM_ESPECE_ESPECE` (`id_espece_animal`),
  CONSTRAINT `FK_RACEANIM_ESPECE_ESPECE` FOREIGN KEY (`id_espece_animal`) REFERENCES `espece` (`id_espece_animal`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `raceanimal`
--

LOCK TABLES `raceanimal` WRITE;
/*!40000 ALTER TABLE `raceanimal` DISABLE KEYS */;
/*!40000 ALTER TABLE `raceanimal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `raisonannulationdemande`
--

DROP TABLE IF EXISTS `raisonannulationdemande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `raisonannulationdemande` (
  `id_raison_annul` int NOT NULL AUTO_INCREMENT,
  `libelle_annul_demande` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_raison_annul`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `raisonannulationdemande`
--

LOCK TABLES `raisonannulationdemande` WRITE;
/*!40000 ALTER TABLE `raisonannulationdemande` DISABLE KEYS */;
/*!40000 ALTER TABLE `raisonannulationdemande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `raisonannulationoffre`
--

DROP TABLE IF EXISTS `raisonannulationoffre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `raisonannulationoffre` (
  `id_annulation_offre` int NOT NULL AUTO_INCREMENT,
  `libele_annulation` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_annulation_offre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `raisonannulationoffre`
--

LOCK TABLES `raisonannulationoffre` WRITE;
/*!40000 ALTER TABLE `raisonannulationoffre` DISABLE KEYS */;
/*!40000 ALTER TABLE `raisonannulationoffre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `raisonannulationprematuree`
--

DROP TABLE IF EXISTS `raisonannulationprematuree`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `raisonannulationprematuree` (
  `id_raison_annul_prem` int NOT NULL AUTO_INCREMENT,
  `libelle_annul_prem` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_raison_annul_prem`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `raisonannulationprematuree`
--

LOCK TABLES `raisonannulationprematuree` WRITE;
/*!40000 ALTER TABLE `raisonannulationprematuree` DISABLE KEYS */;
/*!40000 ALTER TABLE `raisonannulationprematuree` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `raisondesinscriptionutilisateur`
--

DROP TABLE IF EXISTS `raisondesinscriptionutilisateur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `raisondesinscriptionutilisateur` (
  `id_desinscription` int NOT NULL AUTO_INCREMENT,
  `libelle_desinscription` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_desinscription`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `raisondesinscriptionutilisateur`
--

LOCK TABLES `raisondesinscriptionutilisateur` WRITE;
/*!40000 ALTER TABLE `raisondesinscriptionutilisateur` DISABLE KEYS */;
/*!40000 ALTER TABLE `raisondesinscriptionutilisateur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `raisonrefusdemande`
--

DROP TABLE IF EXISTS `raisonrefusdemande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `raisonrefusdemande` (
  `id_motif_refus` int NOT NULL AUTO_INCREMENT,
  `libelle_refus` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_motif_refus`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `raisonrefusdemande`
--

LOCK TABLES `raisonrefusdemande` WRITE;
/*!40000 ALTER TABLE `raisonrefusdemande` DISABLE KEYS */;
/*!40000 ALTER TABLE `raisonrefusdemande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `raisonretraitterrain`
--

DROP TABLE IF EXISTS `raisonretraitterrain`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `raisonretraitterrain` (
  `id_raison_retrait` int NOT NULL AUTO_INCREMENT,
  `libelle_retrait_terrain` int DEFAULT NULL,
  PRIMARY KEY (`id_raison_retrait`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `raisonretraitterrain`
--

LOCK TABLES `raisonretraitterrain` WRITE;
/*!40000 ALTER TABLE `raisonretraitterrain` DISABLE KEYS */;
/*!40000 ALTER TABLE `raisonretraitterrain` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `terrain`
--

DROP TABLE IF EXISTS `terrain`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `terrain` (
  `id_terrain` int NOT NULL AUTO_INCREMENT,
  `id_raison_retrait` int DEFAULT NULL,
  `id_humidite_terraine` int NOT NULL,
  `id_composition_terrain` int NOT NULL,
  `id_pente_terrain` int NOT NULL,
  `id_villeCP` int NOT NULL,
  `id_hauteur_herbe` int NOT NULL,
  `id_utilisateur` int NOT NULL,
  `nom_terrain` varchar(254) DEFAULT NULL,
  `surface_terrain` int DEFAULT NULL,
  `description_terrain` varchar(254) DEFAULT NULL,
  `adresse_terrain` varchar(254) DEFAULT NULL,
  `date_enregistrement_terrain` datetime DEFAULT NULL,
  `photo_terrain` varchar(254) DEFAULT NULL,
  `date_retrait_terrain` datetime DEFAULT NULL,
  PRIMARY KEY (`id_terrain`),
  KEY `FK_TERRAIN_RAISONRET_RAISONRE` (`id_raison_retrait`),
  KEY `FK_TERRAIN_TERRAIN_C_COMPOSIT` (`id_composition_terrain`),
  KEY `FK_TERRAIN_TERRAIN_H_HAUTEURH` (`id_hauteur_herbe`),
  KEY `FK_TERRAIN_TERRAIN_H_HUMIDITE` (`id_humidite_terraine`),
  KEY `FK_TERRAIN_TERRAIN_P_PENTETER` (`id_pente_terrain`),
  KEY `FK_TERRAIN_UTILISATE_UTILISAT` (`id_utilisateur`),
  KEY `FK_TERRAIN_VILLECP_VILLECP` (`id_villeCP`),
  CONSTRAINT `FK_TERRAIN_RAISONRET_RAISONRE` FOREIGN KEY (`id_raison_retrait`) REFERENCES `raisonretraitterrain` (`id_raison_retrait`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_TERRAIN_TERRAIN_C_COMPOSIT` FOREIGN KEY (`id_composition_terrain`) REFERENCES `compositionterrain` (`id_composition_terrain`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_TERRAIN_TERRAIN_H_HAUTEURH` FOREIGN KEY (`id_hauteur_herbe`) REFERENCES `hauteurherbe` (`id_hauteur_herbe`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_TERRAIN_TERRAIN_H_HUMIDITE` FOREIGN KEY (`id_humidite_terraine`) REFERENCES `humiditeterrain` (`id_humidite_terraine`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_TERRAIN_TERRAIN_P_PENTETER` FOREIGN KEY (`id_pente_terrain`) REFERENCES `penteterrain` (`id_pente_terrain`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_TERRAIN_UTILISATE_UTILISAT` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_TERRAIN_VILLECP_VILLECP` FOREIGN KEY (`id_villeCP`) REFERENCES `villecp` (`id_villeCP`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `terrain`
--

LOCK TABLES `terrain` WRITE;
/*!40000 ALTER TABLE `terrain` DISABLE KEYS */;
/*!40000 ALTER TABLE `terrain` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `typeanomalie`
--

DROP TABLE IF EXISTS `typeanomalie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `typeanomalie` (
  `id_type_anomalie` int NOT NULL AUTO_INCREMENT,
  `type_anomalie` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_type_anomalie`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `typeanomalie`
--

LOCK TABLES `typeanomalie` WRITE;
/*!40000 ALTER TABLE `typeanomalie` DISABLE KEYS */;
/*!40000 ALTER TABLE `typeanomalie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `typevegetation`
--

DROP TABLE IF EXISTS `typevegetation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `typevegetation` (
  `id_type_vegetation` int NOT NULL AUTO_INCREMENT,
  `type_vegetation` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_type_vegetation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `typevegetation`
--

LOCK TABLES `typevegetation` WRITE;
/*!40000 ALTER TABLE `typevegetation` DISABLE KEYS */;
/*!40000 ALTER TABLE `typevegetation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `typevegetationfavori`
--

DROP TABLE IF EXISTS `typevegetationfavori`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `typevegetationfavori` (
  `id_type_vegetation` int NOT NULL,
  `id_espece_animal` int NOT NULL,
  PRIMARY KEY (`id_type_vegetation`,`id_espece_animal`),
  KEY `FK_TYPEVEGE_TYPEVEGET_ESPECE` (`id_espece_animal`),
  CONSTRAINT `FK_TYPEVEGE_TYPEVEGET_ESPECE` FOREIGN KEY (`id_espece_animal`) REFERENCES `espece` (`id_espece_animal`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_TYPEVEGE_TYPEVEGET_TYPEVEGE` FOREIGN KEY (`id_type_vegetation`) REFERENCES `typevegetation` (`id_type_vegetation`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `typevegetationfavori`
--

LOCK TABLES `typevegetationfavori` WRITE;
/*!40000 ALTER TABLE `typevegetationfavori` DISABLE KEYS */;
/*!40000 ALTER TABLE `typevegetationfavori` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateur` (
  `id_utilisateur` int NOT NULL AUTO_INCREMENT,
  `id_villeCP` int NOT NULL,
  `id_desinscription` int DEFAULT NULL,
  `nom_utilisateur` varchar(254) DEFAULT NULL,
  `prenom_utilisateur` varchar(254) DEFAULT NULL,
  `mail_utilisateur` varchar(254) DEFAULT NULL,
  `mdp_utilisateur` varchar(254) DEFAULT NULL,
  `e` varchar(254) DEFAULT NULL,
  `date_inscription_utilisateur` datetime DEFAULT NULL,
  `description_utilisateur` varchar(254) DEFAULT NULL,
  `siret_entreprise` bigint DEFAULT NULL,
  `date_desinscription_utilisateur` datetime DEFAULT NULL,
  PRIMARY KEY (`id_utilisateur`),
  KEY `FK_UTILISAT_RAISONDES_RAISONDE` (`id_desinscription`),
  KEY `FK_UTILISAT_VILLECP_VILLECP` (`id_villeCP`),
  CONSTRAINT `FK_UTILISAT_RAISONDES_RAISONDE` FOREIGN KEY (`id_desinscription`) REFERENCES `raisondesinscriptionutilisateur` (`id_desinscription`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_UTILISAT_VILLECP_VILLECP` FOREIGN KEY (`id_villeCP`) REFERENCES `villecp` (`id_villeCP`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateur`
--

LOCK TABLES `utilisateur` WRITE;
/*!40000 ALTER TABLE `utilisateur` DISABLE KEYS */;
/*!40000 ALTER TABLE `utilisateur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `villecp`
--

DROP TABLE IF EXISTS `villecp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `villecp` (
  `id_villeCP` int NOT NULL AUTO_INCREMENT,
  `nom_ville` varchar(254) DEFAULT NULL,
  `code_postal` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_villeCP`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `villecp`
--

LOCK TABLES `villecp` WRITE;
/*!40000 ALTER TABLE `villecp` DISABLE KEYS */;
/*!40000 ALTER TABLE `villecp` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-10 17:31:59
