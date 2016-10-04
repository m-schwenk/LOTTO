-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 29, 2016 at 03:26 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.1

SET time_zone = "+00:00";

--
-- Database: `lotto`
--
CREATE DATABASE IF NOT EXISTS `lotto` DEFAULT CHARACTER SET latin1 COLLATE latin1_german1_ci;
USE `lotto`;

-- --------------------------------------------------------

--
-- Table structure for table `gehoertzu`
--
-- Creation: Sep 29, 2016 at 10:34 AM
--

DROP TABLE IF EXISTS `gehoertzu`;
CREATE TABLE IF NOT EXISTS `gehoertzu` (
  `id_ziehung` int(11) NOT NULL,
  `id_lottoschein` int(11) NOT NULL,
  KEY `id_ziehung` (`id_ziehung`),
  KEY `id_lottoschein` (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german1_ci;

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
-- Creation: Sep 29, 2016 at 10:34 AM
--

DROP TABLE IF EXISTS `lottoschein`;
CREATE TABLE IF NOT EXISTS `lottoschein` (
  `id_lottoschein` int(11) NOT NULL AUTO_INCREMENT,
  `losNummer` char(7) COLLATE latin1_german1_ci NOT NULL,
  `laufZeit` tinyint(1) unsigned NOT NULL,
  `samstagZiehung` tinyint(1) DEFAULT NULL,
  `mittwochZiehung` tinyint(1) DEFAULT NULL,
  `spiel77` tinyint(1) DEFAULT NULL,
  `super6` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german1_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `spiel`
--
-- Creation: Sep 29, 2016 at 10:34 AM
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german1_ci AUTO_INCREMENT=1 ;

--
-- RELATIONS FOR TABLE `spiel`:
--   `id_lottoschein`
--       `lottoschein` -> `id_lottoschein`
--

-- --------------------------------------------------------

--
-- Table structure for table `ziehung`
--
-- Creation: Sep 29, 2016 at 01:22 PM
--

DROP TABLE IF EXISTS `ziehung`;
CREATE TABLE IF NOT EXISTS `ziehung` (
  `id_ziehung` int(11) NOT NULL AUTO_INCREMENT,
  `datum` date NOT NULL,
  `istSamstag` tinyint(1) NOT NULL COMMENT '0 fuer Mi, 1 fuer Sa',
  `Zahl1` tinyint(2) unsigned DEFAULT NULL,
  `Zahl2` tinyint(2) unsigned DEFAULT NULL,
  `Zahl3` tinyint(2) unsigned DEFAULT NULL,
  `Zahl4` tinyint(2) unsigned DEFAULT NULL,
  `Zahl5` tinyint(2) unsigned DEFAULT NULL,
  `Zahl6` tinyint(2) unsigned DEFAULT NULL,
  `superZahl` tinyint(1) unsigned DEFAULT NULL,
  `spiel77` mediumint(7) unsigned zerofill DEFAULT NULL,
  `super6` mediumint(6) unsigned zerofill DEFAULT NULL,
  PRIMARY KEY (`id_ziehung`),
  UNIQUE KEY `id_ziehung` (`id_ziehung`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_german1_ci AUTO_INCREMENT=19 ;

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
