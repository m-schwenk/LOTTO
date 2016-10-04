-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 29, 2016 at 12:13 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.1

-- SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `lottoprojekt`
--
DROP DATABASE IF EXISTS `lotto`;
CREATE DATABASE IF NOT EXISTS `lotto` DEFAULT CHARACTER SET latin1 COLLATE latin1_german1_ci;
USE `lotto`;

-- --------------------------------------------------------

--
-- Table structure for table `gehoertzu`
--

DROP TABLE IF EXISTS `gehoertzu`;
CREATE TABLE IF NOT EXISTS `gehoertzu` (
  `id_ziehung` int(11) NOT NULL,
  `id_lottoschein` int(11) NOT NULL,
  KEY `id_ziehung` (`id_ziehung`),
  KEY `id_lottoschein` (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE latin1_german1_ci;

--
-- RELATIONS FOR TABLE `gehoertzu`:
--   `id_ziehung`
--       `ziehung` -> `id_ziehung`
--   `id_lottoschein`
--       `lottoschein` -> `id_lottoschein`
--

-- --------------------------------------------------------

--
-- Table structure for table `lottoschein`
--

DROP TABLE IF EXISTS `lottoschein`;
CREATE TABLE IF NOT EXISTS `lottoschein` (
  `id_lottoschein` int(11) NOT NULL AUTO_INCREMENT,
  `losNummer` char(7) NOT NULL,
  `laufZeit` tinyint(1) unsigned NOT NULL,
  `samstagZiehung` tinyint(1) DEFAULT NULL,
  `mittwochZiehung` tinyint(1) DEFAULT NULL,
  `spiel77` tinyint(1) DEFAULT NULL,
  `super6` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE latin1_german1_ci AUTO_INCREMENT=1;

-- --------------------------------------------------------

--
-- Table structure for table `spiel`
--

DROP TABLE IF EXISTS `spiel`;
CREATE TABLE IF NOT EXISTS `spiel` (
  `id_spiel` int(11) NOT NULL AUTO_INCREMENT,
  `id_lottoschein` int(11) NOT NULL,
  `spielNummer` tinyint(2) unsigned NOT NULL,
  `zahl1` tinyint(1) unsigned NOT NULL,
  `zahl2` tinyint(1) unsigned NOT NULL,
  `zahl3` tinyint(1) unsigned NOT NULL,
  `zahl4` tinyint(1) unsigned NOT NULL,
  `zahl5` tinyint(1) unsigned NOT NULL,
  `zahl6` tinyint(1) unsigned NOT NULL,
  `superZahl` tinyint(1) unsigned NOT NULL,
  PRIMARY KEY (`id_spiel`),
  KEY `id_lottoschein` (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE latin1_german1_ci AUTO_INCREMENT=1;

--
-- RELATIONS FOR TABLE `spiel`:
--   `id_lottoschein`
--       `lottoschein` -> `id_lottoschein`
--

-- --------------------------------------------------------

--
-- Table structure for table `ziehung`
--

DROP TABLE IF EXISTS `ziehung`;
CREATE TABLE IF NOT EXISTS `ziehung` (
  `id_ziehung` int(11) NOT NULL AUTO_INCREMENT,
  `datum` date NOT NULL,
  `istSamstag` tinyint(1) NOT NULL COMMENT '0 fuer Mi, 1 fuer Sa',
  `spiel77` mediumint(7) unsigned zerofill NOT NULL,
  `super6` mediumint(6) unsigned zerofill NOT NULL,
  PRIMARY KEY (`id_ziehung`),
  UNIQUE KEY `id_ziehung` (`id_ziehung`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE latin1_german1_ci AUTO_INCREMENT=1;

-- --------------------------------------------------------

--
-- Table structure for table `ziehungszahlen`
--

DROP TABLE IF EXISTS `ziehungszahlen`;
CREATE TABLE IF NOT EXISTS `ziehungszahlen` (
  `id_ziehungsZahl` int(11) NOT NULL AUTO_INCREMENT,
  `id_ziehung` int(11) NOT NULL,
  `zahl1` tinyint(2) unsigned NOT NULL,
  `zahl2` tinyint(2) unsigned NOT NULL,
  `zahl3` tinyint(2) unsigned NOT NULL,
  `zahl4` tinyint(2) unsigned NOT NULL,
  `zahl5` tinyint(2) unsigned NOT NULL,
  `zahl6` tinyint(2) unsigned NOT NULL,
  `superZahl` tinyint(1) unsigned NOT NULL,
  PRIMARY KEY (`id_ziehungsZahl`),
  KEY `id_ziehung` (`id_ziehung`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE latin1_german1_ci AUTO_INCREMENT=1;

--
-- RELATIONS FOR TABLE `ziehungszahlen`:
--   `id_ziehung`
--       `ziehung` -> `id_ziehung`
--

--
-- Constraints for dumped tables
--

--
-- Constraints for table `gehoertzu`
--
ALTER TABLE `gehoertzu`
  ADD CONSTRAINT `gehoertzu_ibfk_1` FOREIGN KEY (`id_ziehung`) REFERENCES `ziehung` (`id_ziehung`),
  ADD CONSTRAINT `gehoertzu_ibfk_2` FOREIGN KEY (`id_lottoschein`) REFERENCES `lottoschein` (`id_lottoschein`);

--
-- Constraints for table `spiel`
--
ALTER TABLE `spiel`
  ADD CONSTRAINT `spiel_ibfk_1` FOREIGN KEY (`id_lottoschein`) REFERENCES `lottoschein` (`id_lottoschein`);

--
-- Constraints for table `ziehungszahlen`
--
ALTER TABLE `ziehungszahlen`
  ADD CONSTRAINT `ziehungszahlen_ibfk_1` FOREIGN KEY (`id_ziehung`) REFERENCES `ziehung` (`id_ziehung`);
