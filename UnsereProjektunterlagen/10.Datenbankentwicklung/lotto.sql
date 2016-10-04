-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 04, 2016 at 03:48 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `lotto`
--
CREATE DATABASE IF NOT EXISTS `lotto` DEFAULT CHARACTER SET latin1 COLLATE latin1_german1_ci;
USE `lotto`;

-- --------------------------------------------------------

--
-- Table structure for table `gehoertzu`
--

CREATE TABLE IF NOT EXISTS `gehoertzu` (
  `id_ziehung` int(11) NOT NULL,
  `id_lottoschein` int(11) NOT NULL,
  KEY `id_ziehung` (`id_ziehung`),
  KEY `id_lottoschein` (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german1_ci;

--
-- Dumping data for table `gehoertzu`
--

INSERT INTO `gehoertzu` (`id_ziehung`, `id_lottoschein`) VALUES
(19, 1),
(20, 2),
(21, 3),
(22, 4),
(23, 5),
(24, 6),
(25, 7),
(26, 8),
(27, 9),
(28, 10),
(29, 11),
(30, 12);

-- --------------------------------------------------------

--
-- Table structure for table `lottoschein`
--

CREATE TABLE IF NOT EXISTS `lottoschein` (
  `id_lottoschein` int(11) NOT NULL AUTO_INCREMENT,
  `losNummer` char(7) COLLATE latin1_german1_ci NOT NULL,
  `laufZeit` tinyint(1) unsigned NOT NULL,
  `samstagZiehung` tinyint(1) DEFAULT NULL,
  `mittwochZiehung` tinyint(1) DEFAULT NULL,
  `spiel77` tinyint(1) DEFAULT NULL,
  `super6` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_lottoschein`),
  UNIQUE KEY `id_lottoschein` (`id_lottoschein`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_german1_ci AUTO_INCREMENT=13 ;

--
-- Dumping data for table `lottoschein`
--

INSERT INTO `lottoschein` (`id_lottoschein`, `losNummer`, `laufZeit`, `samstagZiehung`, `mittwochZiehung`, `spiel77`, `super6`) VALUES
(1, '1234567', 1, 1, 0, 0, 0),
(2, '6546546', 1, 1, 0, 0, 0),
(3, '3453455', 1, 1, 0, 0, 0),
(4, '4545454', 1, 1, 0, 0, 0),
(5, '7777777', 1, 1, 0, 0, 0),
(6, '1', 1, 1, 0, 0, 0),
(7, '12', 1, 1, 0, 0, 0),
(8, '12', 1, 1, 0, 0, 0),
(9, '1', 1, 1, 0, 0, 0),
(10, '1111111', 1, 0, 1, 0, 0),
(11, '1111111', 1, 0, 1, 0, 0),
(12, '1', 1, 0, 1, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `spiel`
--

CREATE TABLE IF NOT EXISTS `spiel` (
  `id_spiel` int(11) NOT NULL AUTO_INCREMENT,
  `id_lottoschein` int(11) NOT NULL,
  `spielNummer` tinyint(2) unsigned NOT NULL,
  `zahl1` tinyint(2) unsigned NOT NULL,
  `zahl2` tinyint(2) unsigned NOT NULL,
  `zahl3` tinyint(2) unsigned NOT NULL,
  `zahl4` tinyint(2) unsigned NOT NULL,
  `zahl5` tinyint(2) unsigned NOT NULL,
  `zahl6` tinyint(2) unsigned NOT NULL,
  `superZahl` tinyint(1) unsigned NOT NULL,
  PRIMARY KEY (`id_spiel`),
  KEY `id_lottoschein` (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german1_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ziehung`
--

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_german1_ci AUTO_INCREMENT=31 ;

--
-- Dumping data for table `ziehung`
--

INSERT INTO `ziehung` (`id_ziehung`, `datum`, `istSamstag`, `Zahl1`, `Zahl2`, `Zahl3`, `Zahl4`, `Zahl5`, `Zahl6`, `superZahl`, `spiel77`, `super6`) VALUES
(19, '0000-00-00', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(20, '0000-00-00', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(21, '0000-00-00', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(22, '0000-00-00', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(23, '2016-10-01', 1, 1, 2, 4, 5, 6, 15, 0, NULL, NULL),
(24, '2016-10-01', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(25, '2016-10-01', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(26, '2016-10-01', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(27, '2016-10-01', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(28, '2016-10-05', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(29, '2016-10-05', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(30, '2016-10-05', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

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

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
