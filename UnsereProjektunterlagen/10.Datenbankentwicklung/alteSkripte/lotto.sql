-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Erstellungszeit: 22. Sep 2016 um 15:52
-- Server Version: 5.6.11
-- PHP-Version: 5.5.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Datenbank: `lotto`
--
CREATE DATABASE IF NOT EXISTS `lotto` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `lotto`;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `lottoschein`
--

CREATE TABLE IF NOT EXISTS `lottoschein` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `losnummer` int(10) unsigned NOT NULL,
  `laufzeit` int(10) unsigned DEFAULT NULL,
  `samstagZiehung` tinyint(1) NOT NULL,
  `mittwochZiehung` tinyint(1) NOT NULL,
  `spiel77` int(10) unsigned DEFAULT NULL,
  `super6` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `spiel`
--

CREATE TABLE IF NOT EXISTS `spiel` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `spielNummer` int(2) unsigned NOT NULL,
  `zahlEins` int(2) unsigned NOT NULL,
  `zahlZwei` int(2) unsigned NOT NULL,
  `zahlDrei` int(2) unsigned NOT NULL,
  `zahlVier` int(2) unsigned NOT NULL,
  `zahlFuenf` int(2) unsigned NOT NULL,
  `zahlSechs` int(2) unsigned NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `ziehung`
--

CREATE TABLE IF NOT EXISTS `ziehung` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `istSamstag` tinyint(1) NOT NULL,
  `datum` date NOT NULL,
  `spiel77` int(11) DEFAULT NULL,
  `super6` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `ziehungszahlen`
--

CREATE TABLE IF NOT EXISTS `ziehungszahlen` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `zahlEins` int(11) NOT NULL,
  `zahlZwei` int(11) NOT NULL,
  `zahlDrei` int(11) NOT NULL,
  `zahlVier` int(11) NOT NULL,
  `zahlFuenf` int(11) NOT NULL,
  `zahlSechs` int(11) NOT NULL,
  `superZahl` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
