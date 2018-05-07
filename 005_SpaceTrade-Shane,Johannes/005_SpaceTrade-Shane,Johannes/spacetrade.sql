-- phpMyAdmin SQL Dump
-- version 4.7.8
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Apr 30, 2018 at 08:55 AM
-- Server version: 5.7.21
-- PHP Version: 7.1.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `spacetrade`
--

-- --------------------------------------------------------

--
-- Table structure for table `erze`
--

CREATE TABLE `erze` (
  `eName` varchar(255) NOT NULL,
  `eID` int(4) NOT NULL,
  `ePreis` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `erze`
--

INSERT INTO `erze` (`eName`, `eID`, `ePreis`) VALUES
('Eisen ', 1, 10),
('Gold ', 2, 100),
('Kupfer', 3, 40),
('Silber', 4, 50),
('Bronze ', 5, 5),
('Titan', 6, 200),
('Zink', 7, 30),
('Platin', 8, 80),
('Aluminium ', 9, 40),
('Chrom', 10, 60);

-- --------------------------------------------------------

--
-- Table structure for table `materialien`
--

CREATE TABLE `materialien` (
  `mName` varchar(255) NOT NULL,
  `mID` int(4) NOT NULL,
  `mPreis` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `materialien`
--

INSERT INTO `materialien` (`mName`, `mID`, `mPreis`) VALUES
('Stahlbarren', 1, 20),
('Goldbarren', 2, 250),
('Holzbretter', 3, 10),
('Steine', 4, 5),
('Stahlplatten', 5, 100),
('Öl', 6, 50),
('Treibstoff', 7, 70),
('Mikroprozessor', 8, 500),
('Glas', 9, 30),
('Drähte', 10, 35);

-- --------------------------------------------------------

--
-- Table structure for table `planeten`
--

CREATE TABLE `planeten` (
  `pName` varchar(255) NOT NULL,
  `pID` int(4) NOT NULL,
  `eID` int(4) DEFAULT NULL,
  `pEntfernung` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `raumstationen`
--

CREATE TABLE `raumstationen` (
  `rName` varchar(255) NOT NULL,
  `rID` int(4) NOT NULL,
  `mID` int(4) DEFAULT NULL,
  `pEntfernung` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `erze`
--
ALTER TABLE `erze`
  ADD PRIMARY KEY (`eID`);

--
-- Indexes for table `materialien`
--
ALTER TABLE `materialien`
  ADD PRIMARY KEY (`mID`);

--
-- Indexes for table `planeten`
--
ALTER TABLE `planeten`
  ADD PRIMARY KEY (`pID`),
  ADD KEY `eID` (`eID`);

--
-- Indexes for table `raumstationen`
--
ALTER TABLE `raumstationen`
  ADD PRIMARY KEY (`rID`),
  ADD KEY `mID` (`mID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `erze`
--
ALTER TABLE `erze`
  MODIFY `eID` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `materialien`
--
ALTER TABLE `materialien`
  MODIFY `mID` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `planeten`
--
ALTER TABLE `planeten`
  MODIFY `pID` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `raumstationen`
--
ALTER TABLE `raumstationen`
  MODIFY `rID` int(4) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `planeten`
--
ALTER TABLE `planeten`
  ADD CONSTRAINT `planeten_ibfk_1` FOREIGN KEY (`eID`) REFERENCES `erze` (`eID`);

--
-- Constraints for table `raumstationen`
--
ALTER TABLE `raumstationen`
  ADD CONSTRAINT `raumstationen_ibfk_1` FOREIGN KEY (`mID`) REFERENCES `materialien` (`mID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
