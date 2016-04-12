-- phpMyAdmin SQL Dump
-- version 4.5.0.2
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Jeu 12 Novembre 2015 à 21:13
-- Version du serveur :  10.0.17-MariaDB
-- Version de PHP :  5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  map
--
CREATE DATABASE IF NOT EXISTS map DEFAULT CHARACTER SET latin1 COLLATE latin1_general_ci;
USE map;

-- --------------------------------------------------------

--
-- Structure de la table delivery
--

DROP TABLE IF EXISTS delivery;
CREATE TABLE delivery (
  `dlm_id` int(10) UNSIGNED NOT NULL,
  `dlm_cost` decimal(12,2) UNSIGNED NOT NULL,
  `dlm_date` varchar(10) COLLATE latin1_general_ci NOT NULL,
  `dlm_rec_date` varchar(10) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table delivery_detail
--

DROP TABLE IF EXISTS delivery_detail;
CREATE TABLE delivery_detail (
  `dlm_id` int(10) UNSIGNED NOT NULL,
  `prd_id` int(10) UNSIGNED NOT NULL,
  `dld_prd_qty` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table department
--

DROP TABLE IF EXISTS department;
CREATE TABLE department (
  `dep_id` int(10) UNSIGNED NOT NULL,
  `dep_name` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `dep_desc` varchar(255) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Contenu de la table department
--

INSERT INTO department (dep_id, dep_name, dep_desc) VALUES
(1, 'Technologies de l''information', '');

-- --------------------------------------------------------

--
-- Structure de la table employee
--

DROP TABLE IF EXISTS employee;
CREATE TABLE employee (
  `emp_id` int(10) UNSIGNED NOT NULL,
  `sit_id` int(10) UNSIGNED NOT NULL,
  `dep_id` int(10) UNSIGNED NOT NULL,
  `rol_id` int(10) UNSIGNED NOT NULL,
  `emp_fname` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `emp_lname` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `emp_email` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `emp_date_begin` varchar(10) COLLATE latin1_general_ci NOT NULL,
  `emp_date_end` varchar(10) COLLATE latin1_general_ci NOT NULL,
  `emp_login` varchar(16) COLLATE latin1_general_ci NOT NULL,
  `emp_pw` varchar(40) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Contenu de la table employee
--

INSERT INTO employee (emp_id, sit_id, dep_id, rol_id, emp_fname, emp_lname, emp_email, emp_date_begin, emp_date_end, emp_login, emp_pw) VALUES
(1, 1, 1, 1, 'admin_fname', 'admin_lname', 'admin@email.com', '', '', 'admin', 'da39a3ee5e6b4b0d3255bfef95601890afd80709'),
(2, 1, 1, 2, 'feed_fname', 'feed_lname', 'feed@email.com', '', '', 'feed', 'da39a3ee5e6b4b0d3255bfef95601890afd80709'),
(3, 1, 1, 3, 'stock_fname', 'stock_lname', 'stock@email.com', '', '', 'stock', 'da39a3ee5e6b4b0d3255bfef95601890afd80709'),
(4, 1, 1, 4, 'supplier_fname', 'supplier_lname', 'supplier@email.com', '', '', 'supplier', 'da39a3ee5e6b4b0d3255bfef95601890afd80709'),
(5, 1, 1, 5, 'manager_fname', 'manager_lname', 'manager@email.com', '', '', 'manager', 'da39a3ee5e6b4b0d3255bfef95601890afd80709');

-- --------------------------------------------------------

--
-- Structure de la table invoice
--

DROP TABLE IF EXISTS invoice;
CREATE TABLE invoice (
  `inv_id` int(10) UNSIGNED NOT NULL,
  `inv_sup_no` varchar(20) COLLATE latin1_general_ci NOT NULL,
  `inv_amount` decimal(12,2) UNSIGNED NOT NULL,
  `inv_date_due` varchar(10) COLLATE latin1_general_ci NOT NULL,
  `inv_date_paid` varchar(10) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `log`
--

DROP TABLE IF EXISTS log;
CREATE TABLE log (
  `log_id` int(10) UNSIGNED NOT NULL,
  `emp_id` int(10) UNSIGNED NOT NULL,
  `log_datetime` varchar(19) COLLATE latin1_general_ci NOT NULL,
  `log_desc` varchar(100) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table porder
--

DROP TABLE IF EXISTS porder;
CREATE TABLE porder (
  `pom_id` int(10) UNSIGNED NOT NULL,
  `sit_id` int(10) UNSIGNED NOT NULL,
  `emp_id` int(10) UNSIGNED NOT NULL,
  `inv_id` int(10) UNSIGNED NOT NULL,
  `dlm_id` int(10) UNSIGNED NOT NULL,
  `sup_id` int(10) UNSIGNED NOT NULL,
  `pom_datetime` varchar(19) COLLATE latin1_general_ci NOT NULL,
  `pom_desc` varchar(255) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table porder_detail
--

DROP TABLE IF EXISTS porder_detail;
CREATE TABLE porder_detail (
  `pom_id` int(10) UNSIGNED NOT NULL,
  `prd_id` int(10) UNSIGNED NOT NULL,
  `pod_prd_qty` int(10) UNSIGNED NOT NULL,
  `pod_prd_price` decimal(12,2) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table product
--

DROP TABLE IF EXISTS product;
CREATE TABLE product (
  `prd_id` int(10) UNSIGNED NOT NULL,
  `sup_id` int(10) UNSIGNED NOT NULL,
  `prd_sup_no` varchar(20) COLLATE latin1_general_ci NOT NULL,
  `prd_name` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `prd_price` decimal(12,2) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table role
--

DROP TABLE IF EXISTS role;
CREATE TABLE `role` (
  `rol_id` int(10) UNSIGNED NOT NULL,
  `rol_name` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `rol_desc` varchar(255) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Contenu de la table role
--

INSERT INTO role (rol_id, rol_name, rol_desc) VALUES
(1, 'admin', ''),
(2, 'feed', ''),
(3, 'stock', ''),
(4, 'supplier', ''),
(5, 'manager', '');

-- --------------------------------------------------------

--
-- Structure de la table site
--

DROP TABLE IF EXISTS site;
CREATE TABLE site (
  `sit_id` int(10) UNSIGNED NOT NULL,
  `sit_name` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `sit_tel` varchar(14) COLLATE latin1_general_ci NOT NULL,
  `sit_adr_no` varchar(10) COLLATE latin1_general_ci NOT NULL,
  `sit_adr_street` varchar(80) COLLATE latin1_general_ci NOT NULL,
  `sit_adr_city` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `sit_adr_prov` varchar(2) COLLATE latin1_general_ci NOT NULL,
  `sit_adr_pcode` varchar(7) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Contenu de la table site
--

INSERT INTO site (sit_id, sit_name, sit_tel, sit_adr_no, sit_adr_street, sit_adr_city, sit_adr_prov, sit_adr_pcode) VALUES
(1, 'Collège de Rosemont', '514-376-1620', '6400', '16e avenue', 'Montréal', 'QC', 'H1X 2S9');

-- --------------------------------------------------------

--
-- Structure de la table site_supplier
--

DROP TABLE IF EXISTS site_supplier;
CREATE TABLE site_supplier (
  `sit_id` int(10) UNSIGNED NOT NULL,
  `sup_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table stock
--

DROP TABLE IF EXISTS stock;
CREATE TABLE stock (
  `sit_id` int(10) UNSIGNED NOT NULL,
  `prd_id` int(10) UNSIGNED NOT NULL,
  `stk_prd_qty` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table stockout
--

DROP TABLE IF EXISTS stockout;
CREATE TABLE stockout (
  `som_id` int(10) UNSIGNED NOT NULL,
  `sit_id` int(10) UNSIGNED NOT NULL,
  `emp_id` int(10) UNSIGNED NOT NULL,
  `som_datetime` varchar(19) COLLATE latin1_general_ci NOT NULL,
  `som_lost_flag` varchar(1) COLLATE latin1_general_ci NOT NULL,
  `som_desc` varchar(255) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table stockout_detail
--

DROP TABLE IF EXISTS stockout_detail;
CREATE TABLE stockout_detail (
  `som_id` int(10) UNSIGNED NOT NULL,
  `prd_id` int(10) UNSIGNED NOT NULL,
  `sod_prd_qty` int(10) UNSIGNED NOT NULL,
  `sod_prd_price` decimal(12,2) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table supplier
--

DROP TABLE IF EXISTS supplier;
CREATE TABLE supplier (
  `sup_id` int(10) UNSIGNED NOT NULL,
  `sup_name` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `sup_tel` varchar(14) COLLATE latin1_general_ci NOT NULL,
  `sup_adr_no` varchar(10) COLLATE latin1_general_ci NOT NULL,
  `sup_adr_street` varchar(80) COLLATE latin1_general_ci NOT NULL,
  `sup_adr_city` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `sup_adr_prov` varchar(2) COLLATE latin1_general_ci NOT NULL,
  `sup_adr_pcode` varchar(7) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Contenu de la table supplier
--

INSERT INTO supplier (sup_id, sup_name, sup_tel, sup_adr_no, sup_adr_street, sup_adr_city, sup_adr_prov, sup_adr_pcode) VALUES
(1, 'Supp1', '514-123-4567', '123', 'Main', 'City', 'QC', 'H1H 1H1'),
(2, 'Supp2', '514-123-4567', '123', 'Main', 'City', 'QC', 'H1H 1H1'),
(3, 'Supp3', '514-123-4567', '123', 'Main', 'City', 'QC', 'H1H 1H1'),
(4, 'Supp4', '514-123-4567', '123', 'Main', 'City', 'QC', 'H1H 1H1'),
(5, 'Supp5', '514-123-4567', '123', 'Main', 'City', 'QC', 'H1H 1H1'),
(6, 'Supp6', '514-123-4567', '123', 'Main', 'City', 'QC', 'H1H 1H1');

--
-- Index pour les tables exportées
--

--
-- Index pour la table delivery
--
ALTER TABLE delivery
  ADD PRIMARY KEY (`dlm_id`);

--
-- Index pour la table delivery_detail
--
ALTER TABLE delivery_detail
  ADD PRIMARY KEY (`dlm_id`,`prd_id`),
  ADD KEY `I_FK_DELIVERY_DETAIL_DELIVERY` (`dlm_id`),
  ADD KEY `I_FK_DELIVERY_DETAIL_PRODUCT` (`prd_id`);

--
-- Index pour la table department
--
ALTER TABLE department
  ADD PRIMARY KEY (`dep_id`);

--
-- Index pour la table employee
--
ALTER TABLE employee
  ADD PRIMARY KEY (`emp_id`),
  ADD UNIQUE KEY `I_UN_EMPLOYEE_EMP_LOGIN` (`emp_login`),
  ADD KEY `I_FK_EMPLOYEE_SITE` (`sit_id`),
  ADD KEY `I_FK_EMPLOYEE_DEPARTMENT` (`dep_id`),
  ADD KEY `I_FK_EMPLOYEE_ROLE` (`rol_id`);

--
-- Index pour la table invoice
--
ALTER TABLE invoice
  ADD PRIMARY KEY (`inv_id`);

--
-- Index pour la table `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`log_id`),
  ADD KEY `I_FK_LOG_EMPLOYEE` (`emp_id`);

--
-- Index pour la table porder
--
ALTER TABLE porder
  ADD PRIMARY KEY (`pom_id`),
  ADD KEY `I_FK_PORDER_SITE` (`sit_id`),
  ADD KEY `I_FK_PORDER_EMPLOYEE` (`emp_id`),
  ADD KEY `I_FK_PORDER_INVOICE` (`inv_id`),
  ADD KEY `I_FK_PORDER_DELIVERY` (`dlm_id`),
  ADD KEY `I_FK_PORDER_SUPPLIER` (`sup_id`);

--
-- Index pour la table porder_detail
--
ALTER TABLE porder_detail
  ADD PRIMARY KEY (`pom_id`,`prd_id`),
  ADD KEY `I_FK_PORDER_DETAIL_PORDER` (`pom_id`),
  ADD KEY `I_FK_PORDER_DETAIL_PRODUCT` (`prd_id`);

--
-- Index pour la table product
--
ALTER TABLE product
  ADD PRIMARY KEY (`prd_id`),
  ADD KEY `I_FK_PRODUCT_SUPPLIER` (`sup_id`);

--
-- Index pour la table role
--
ALTER TABLE role
  ADD PRIMARY KEY (`rol_id`);

--
-- Index pour la table site
--
ALTER TABLE site
  ADD PRIMARY KEY (`sit_id`);

--
-- Index pour la table site_supplier
--
ALTER TABLE site_supplier
  ADD PRIMARY KEY (`sit_id`,`sup_id`),
  ADD KEY `I_FK_SITE_SUPPLIER_SITE` (`sit_id`),
  ADD KEY `I_FK_SITE_SUPPLIER_SUPPLIER` (`sup_id`);

--
-- Index pour la table stock
--
ALTER TABLE stock
  ADD PRIMARY KEY (`sit_id`,`prd_id`),
  ADD KEY `I_FK_STOCK_SITE` (`sit_id`),
  ADD KEY `I_FK_STOCK_PRODUCT` (`prd_id`);

--
-- Index pour la table stockout
--
ALTER TABLE stockout
  ADD PRIMARY KEY (`som_id`),
  ADD KEY `I_FK_STOCKOUT_SITE` (`sit_id`),
  ADD KEY `I_FK_STOCKOUT_EMPLOYEE` (`emp_id`);

--
-- Index pour la table stockout_detail
--
ALTER TABLE stockout_detail
  ADD PRIMARY KEY (`som_id`,`prd_id`),
  ADD KEY `I_FK_STOCKOUT_DETAIL_STOCKOUT` (`som_id`),
  ADD KEY `I_FK_STOCKOUT_DETAIL_PRODUCT` (`prd_id`);

--
-- Index pour la table supplier
--
ALTER TABLE supplier
  ADD PRIMARY KEY (`sup_id`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table delivery
--
ALTER TABLE delivery
  MODIFY `dlm_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table department
--
ALTER TABLE department
  MODIFY `dep_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table employee
--
ALTER TABLE employee
  MODIFY `emp_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT pour la table invoice
--
ALTER TABLE invoice
  MODIFY `inv_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table `log`
--
ALTER TABLE `log`
  MODIFY `log_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table porder
--
ALTER TABLE porder
  MODIFY `pom_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table product
--
ALTER TABLE product
  MODIFY `prd_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table role
--
ALTER TABLE role
  MODIFY `rol_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT pour la table site
--
ALTER TABLE site
  MODIFY `sit_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table stockout
--
ALTER TABLE stockout
  MODIFY `som_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table supplier
--
ALTER TABLE supplier
  MODIFY `sup_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table delivery_detail
--
ALTER TABLE delivery_detail
  ADD CONSTRAINT `FK_DELIVERY_DETAIL_DELIVERY` FOREIGN KEY (`dlm_id`) REFERENCES `delivery` (`dlm_id`),
  ADD CONSTRAINT `FK_DELIVERY_DETAIL_PRODUCT` FOREIGN KEY (`prd_id`) REFERENCES `product` (`prd_id`);

--
-- Contraintes pour la table employee
--
ALTER TABLE employee
  ADD CONSTRAINT `FK_EMPLOYEE_DEPARTMENT` FOREIGN KEY (`dep_id`) REFERENCES `department` (`dep_id`),
  ADD CONSTRAINT `FK_EMPLOYEE_ROLE` FOREIGN KEY (`rol_id`) REFERENCES `role` (`rol_id`),
  ADD CONSTRAINT `FK_EMPLOYEE_SITE` FOREIGN KEY (`sit_id`) REFERENCES `site` (`sit_id`);

--
-- Contraintes pour la table `log`
--
ALTER TABLE `log`
  ADD CONSTRAINT `FK_LOG_EMPLOYEE` FOREIGN KEY (`emp_id`) REFERENCES `employee` (`emp_id`);

--
-- Contraintes pour la table porder
--
ALTER TABLE porder
  ADD CONSTRAINT `FK_PORDER_DELIVERY` FOREIGN KEY (`dlm_id`) REFERENCES `delivery` (`dlm_id`),
  ADD CONSTRAINT `FK_PORDER_EMPLOYEE` FOREIGN KEY (`emp_id`) REFERENCES `employee` (`emp_id`),
  ADD CONSTRAINT `FK_PORDER_INVOICE` FOREIGN KEY (`inv_id`) REFERENCES `invoice` (`inv_id`),
  ADD CONSTRAINT `FK_PORDER_SITE` FOREIGN KEY (`sit_id`) REFERENCES `site` (`sit_id`),
  ADD CONSTRAINT `FK_PORDER_SUPPLIER` FOREIGN KEY (`sup_id`) REFERENCES `supplier` (`sup_id`);

--
-- Contraintes pour la table porder_detail
--
ALTER TABLE porder_detail
  ADD CONSTRAINT `FK_PORDER_DETAIL_PORDER` FOREIGN KEY (`pom_id`) REFERENCES `porder` (`pom_id`),
  ADD CONSTRAINT `FK_PORDER_DETAIL_PRODUCT` FOREIGN KEY (`prd_id`) REFERENCES `product` (`prd_id`);

--
-- Contraintes pour la table product
--
ALTER TABLE product
  ADD CONSTRAINT `FK_PRODUCT_SUPPLIER` FOREIGN KEY (`sup_id`) REFERENCES `supplier` (`sup_id`);

--
-- Contraintes pour la table site_supplier
--
ALTER TABLE site_supplier
  ADD CONSTRAINT `FK_SITE_SUPPLIER_SITE` FOREIGN KEY (`sit_id`) REFERENCES `site` (`sit_id`),
  ADD CONSTRAINT `FK_SITE_SUPPLIER_SUPPLIER` FOREIGN KEY (`sup_id`) REFERENCES `supplier` (`sup_id`);

--
-- Contraintes pour la table stock
--
ALTER TABLE stock
  ADD CONSTRAINT `FK_STOCK_PRODUCT` FOREIGN KEY (`prd_id`) REFERENCES `product` (`prd_id`),
  ADD CONSTRAINT `FK_STOCK_SITE` FOREIGN KEY (`sit_id`) REFERENCES `site` (`sit_id`);

--
-- Contraintes pour la table stockout
--
ALTER TABLE stockout
  ADD CONSTRAINT `FK_STOCKOUT_EMPLOYEE` FOREIGN KEY (`emp_id`) REFERENCES `employee` (`emp_id`),
  ADD CONSTRAINT `FK_STOCKOUT_SITE` FOREIGN KEY (`sit_id`) REFERENCES `site` (`sit_id`);

--
-- Contraintes pour la table stockout_detail
--
ALTER TABLE stockout_detail
  ADD CONSTRAINT `FK_STOCKOUT_DETAIL_PRODUCT` FOREIGN KEY (`prd_id`) REFERENCES `product` (`prd_id`),
  ADD CONSTRAINT `FK_STOCKOUT_DETAIL_STOCKOUT` FOREIGN KEY (`som_id`) REFERENCES `stockout` (`som_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
