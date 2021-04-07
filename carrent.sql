-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 17, 2019 at 06:31 PM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `carrent`
--

-- --------------------------------------------------------

--
-- Table structure for table `car`
--

CREATE TABLE `car` (
  `CarID` int(10) NOT NULL,
  `Rate` int(7) NOT NULL,
  `Brand` varchar(15) COLLATE utf8_bin NOT NULL,
  `Model` varchar(15) COLLATE utf8_bin NOT NULL,
  `PlateNo` varchar(15) COLLATE utf8_bin NOT NULL,
  `Type` varchar(10) COLLATE utf8_bin NOT NULL,
  `Seater` varchar(10) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `car`
--

INSERT INTO `car` (`CarID`, `Rate`, `Brand`, `Model`, `PlateNo`, `Type`, `Seater`) VALUES
(1, 1000, 'BMW', 'XS-1009', '456-123', 'MPV', 'Four'),
(2, 245, 'Audi', 'GH-111', '231', 'Sedan', 'Five'),
(3, 2000, 'Ford', 'P300', '125-14', 'Crossover', 'Nine'),
(4, 1300, 'Tesla', 'XS-110', '431-42-A', 'Hatchback', 'Five'),
(5, 1000, 'Toyota', 'Y800', '890-255', 'SUV', 'Four'),
(6, 1599, 'Chrysler', 'JS-13409', '246-121', 'Sedan', 'Nine');

-- --------------------------------------------------------

--
-- Table structure for table `clientprofile`
--

CREATE TABLE `clientprofile` (
  `ClientID` int(10) NOT NULL,
  `FirstName` varchar(20) COLLATE utf8_bin NOT NULL,
  `MiddleName` varchar(20) COLLATE utf8_bin NOT NULL,
  `LastName` varchar(20) COLLATE utf8_bin NOT NULL,
  `ContactNo` int(11) NOT NULL,
  `LicenseNo` int(20) NOT NULL,
  `Age` int(3) NOT NULL,
  `Birthday` varchar(11) COLLATE utf8_bin NOT NULL,
  `Address` varchar(50) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `clientprofile`
--

INSERT INTO `clientprofile` (`ClientID`, `FirstName`, `MiddleName`, `LastName`, `ContactNo`, `LicenseNo`, `Age`, `Birthday`, `Address`) VALUES
(1, 'Glenn', 'Mark', 'Flores', 91231412, 111111, 23, '01/01/1995 ', 'Dipolog City'),
(2, 'Jo', 'Nas', 'Alolino', 912341211, 891, 24, '17/12/1994 ', 'Dipolog City'),
(3, 'John', 'Paul', 'Zero', 912441211, 888, 25, '17/12/1994 ', 'Dapitan City');

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE `transactions` (
  `RentID` int(6) NOT NULL,
  `ClientID` int(6) DEFAULT NULL,
  `CarID` int(6) DEFAULT NULL,
  `ClientName` varchar(30) COLLATE utf8_bin DEFAULT NULL,
  `CarModel` varchar(15) COLLATE utf8_bin DEFAULT NULL,
  `CarBrand` varchar(15) COLLATE utf8_bin DEFAULT NULL,
  `CarRate` int(6) DEFAULT NULL,
  `RentDate` varchar(11) COLLATE utf8_bin NOT NULL,
  `RentFee` int(6) NOT NULL,
  `InsuranceFee` int(6) NOT NULL,
  `TotalCost` int(6) NOT NULL,
  `NoofDays` int(6) NOT NULL,
  `IsReturn` varchar(10) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `transactions`
--

INSERT INTO `transactions` (`RentID`, `ClientID`, `CarID`, `ClientName`, `CarModel`, `CarBrand`, `CarRate`, `RentDate`, `RentFee`, `InsuranceFee`, `TotalCost`, `NoofDays`, `IsReturn`) VALUES
(1, 1, 1, 'Glenn Mark Flores', 'XS-1009', 'BMW', 1000, '17/12/2019 ', 1, 11, 6512, 12, 'True'),
(2, 0, 0, 'John Paul Zero', 'XS-110', 'Tesla', 1300, '17/12/2019 ', 0, 0, 10800, 5, 'True'),
(3, 3, 0, 'John Paul Zero', 'XS-110', 'Tesla', 1300, '17/12/2019 ', 0, 0, 10800, 5, 'True');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `car`
--
ALTER TABLE `car`
  ADD PRIMARY KEY (`CarID`);

--
-- Indexes for table `clientprofile`
--
ALTER TABLE `clientprofile`
  ADD PRIMARY KEY (`ClientID`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`RentID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `car`
--
ALTER TABLE `car`
  MODIFY `CarID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `clientprofile`
--
ALTER TABLE `clientprofile`
  MODIFY `ClientID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11116;

--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `RentID` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
