-- phpMyAdmin SQL Dump
-- version 3.2.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Oct 03, 2013 at 01:15 PM
-- Server version: 5.1.41
-- PHP Version: 5.3.1

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `pmisdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblproduct`
--

CREATE TABLE IF NOT EXISTS `tblproduct` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `p_desc` varchar(255) NOT NULL,
  `p_generic` varchar(255) NOT NULL,
  `p_unitsize` varchar(11) NOT NULL,
  `p_formulation` varchar(100) NOT NULL,
  `p_category` varchar(100) NOT NULL,
  `p_expiration` varchar(100) NOT NULL,
  `p_stocks` int(11) NOT NULL,
  `p_price` varchar(11) NOT NULL,
  `p_vat` varchar(11) NOT NULL,
  `p_sellprice` varchar(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `tblproduct`
--


-- --------------------------------------------------------

--
-- Table structure for table `tblsales`
--

CREATE TABLE IF NOT EXISTS `tblsales` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `s_date` varchar(100) NOT NULL,
  `transaction_no` varchar(100) NOT NULL,
  `p_id` int(11) NOT NULL,
  `p_desc` varchar(300) NOT NULL,
  `p_sellprice` varchar(11) NOT NULL,
  `s_qty` int(11) NOT NULL,
  `s_total` varchar(11) NOT NULL,
  `p_vat` varchar(11) NOT NULL,
  `p_price` varchar(11) NOT NULL,
  `c_total` varchar(30) NOT NULL,
  `c_cash` varchar(30) NOT NULL,
  `c_change` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `tblsales`
--


-- --------------------------------------------------------

--
-- Table structure for table `tbluser`
--

CREATE TABLE IF NOT EXISTS `tbluser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `u_fullname` varchar(200) NOT NULL,
  `u_password` varchar(100) NOT NULL,
  `u_type` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `tbluser`
--

INSERT INTO `tbluser` (`id`, `u_fullname`, `u_password`, `u_type`) VALUES
(2, 'testrun', '12345', 'cashier');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
