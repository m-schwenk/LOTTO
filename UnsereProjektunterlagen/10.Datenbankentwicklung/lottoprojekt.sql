-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Erstellungszeit: 23. Sep 2016 um 14:51
-- Server Version: 5.6.11
-- PHP-Version: 5.5.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Datenbank: `lottoprojekt`
--
CREATE DATABASE IF NOT EXISTS `lottoprojekt` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `lottoprojekt`;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `gehoertzu`
--

CREATE TABLE IF NOT EXISTS `gehoertzu` (
  `id_ziehung` int(11) NOT NULL,
  `id_lottoschein` int(11) NOT NULL,
  KEY `id_ziehung` (`id_ziehung`),
  KEY `id_lottoschein` (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `lottoschein`
--

CREATE TABLE IF NOT EXISTS `lottoschein` (
  `id_lottoschein` int(11) NOT NULL,
  `losNummer` int(11) NOT NULL,
  `laufZeit` int(11) NOT NULL,
  `samstagZiehung` tinyint(4) DEFAULT NULL,
  `mittwochZiehung` tinyint(4) DEFAULT NULL,
  `spiel77` tinyint(4) DEFAULT NULL,
  `super6` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `spiel`
--

CREATE TABLE IF NOT EXISTS `spiel` (
  `id_spiel` int(11) NOT NULL,
  `id_lottoschein` int(11) NOT NULL,
  `spielNummer` int(11) NOT NULL,
  `zahl1` int(11) NOT NULL,
  `zahl2` int(11) NOT NULL,
  `zahl3` int(11) NOT NULL,
  `zahl4` int(11) NOT NULL,
  `zahl5` int(11) NOT NULL,
  `zahl6` int(11) NOT NULL,
  `superZahl` int(11) NOT NULL,
  PRIMARY KEY (`id_spiel`),
  KEY `id_lottoschein` (`id_lottoschein`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `ziehung`
--

CREATE TABLE IF NOT EXISTS `ziehung` (
  `id_ziehung` int(11) NOT NULL,
  `datum` date NOT NULL,
  `istSamstag` tinyint(4) NOT NULL,
  `spiel77` int(11) NOT NULL,
  `super6` int(11) NOT NULL,
  PRIMARY KEY (`id_ziehung`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `ziehungszahl`
--

CREATE TABLE IF NOT EXISTS `ziehungszahl` (
  `id_ziehungsZahl` int(11) NOT NULL,
  `id_ziehung` int(11) NOT NULL,
  `zahl1` int(11) NOT NULL,
  `zahl2` int(11) NOT NULL,
  `zahl3` int(11) NOT NULL,
  `zahl4` int(11) NOT NULL,
  `zahl5` int(11) NOT NULL,
  `zahl6` int(11) NOT NULL,
  `superZahl` int(11) NOT NULL,
  PRIMARY KEY (`id_ziehungsZahl`),
  KEY `id_ziehung` (`id_ziehung`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `gehoertzu`
--
ALTER TABLE `gehoertzu`
  ADD CONSTRAINT `gehoertzu_ibfk_1` FOREIGN KEY (`id_ziehung`) REFERENCES `ziehung` (`id_ziehung`),
  ADD CONSTRAINT `gehoertzu_ibfk_2` FOREIGN KEY (`id_lottoschein`) REFERENCES `lottoschein` (`id_lottoschein`);

--
-- Constraints der Tabelle `spiel`
--
ALTER TABLE `spiel`
  ADD CONSTRAINT `spiel_ibfk_1` FOREIGN KEY (`id_lottoschein`) REFERENCES `lottoschein` (`id_lottoschein`);

--
-- Constraints der Tabelle `ziehungszahl`
--
ALTER TABLE `ziehungszahl`
  ADD CONSTRAINT `ziehungszahl_ibfk_1` FOREIGN KEY (`id_ziehung`) REFERENCES `ziehung` (`id_ziehung`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
