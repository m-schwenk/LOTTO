-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 28, 2016 at 04:39 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `lottoprojekt`
--
CREATE DATABASE IF NOT EXISTS `lottoprojekt` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `lottoprojekt`;

-- --------------------------------------------------------

--
-- Table structure for table `gehoertzu`
--

CREATE TABLE IF NOT EXISTS `gehoertzu` (
  `id_ziehung` int(11) NOT NULL,
  `id_lottoschein` int(11) NOT NULL,
  KEY `id_ziehung` (`id_ziehung`),
  KEY `id_lottoschein` (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `lottoschein`
--

CREATE TABLE IF NOT EXISTS `lottoschein` (
  `id_lottoschein` int(11) NOT NULL,
  `losNummer` char(7) NOT NULL,
  `laufZeit` tinyint(1) unsigned NOT NULL,
  `samstagZiehung` tinyint(1) DEFAULT NULL,
  `mittwochZiehung` tinyint(1) DEFAULT NULL,
  `spiel77` tinyint(1) DEFAULT NULL,
  `super6` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `spiel`
--

CREATE TABLE IF NOT EXISTS `spiel` (
  `id_spiel` int(11) NOT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `ziehung`
--

CREATE TABLE IF NOT EXISTS `ziehung` (
  `id_ziehung` int(11) NOT NULL,
  `datum` date NOT NULL,
  `istSamstag` tinyint(1) NOT NULL COMMENT '0 fuer Mi, 1 fuer Sa',
  `spiel77` mediumint(7) unsigned zerofill NOT NULL,
  `super6` mediumint(6) unsigned zerofill NOT NULL,
  PRIMARY KEY (`id_ziehung`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `ziehungszahlen`
--

CREATE TABLE IF NOT EXISTS `ziehungszahlen` (
  `id_ziehungsZahl` int(11) NOT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
