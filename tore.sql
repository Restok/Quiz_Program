-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 26, 2018 at 09:59 PM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tore`
--

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `id` int(11) NOT NULL,
  `category` varchar(255) NOT NULL,
  `question` varchar(767) NOT NULL,
  `answer_A` varchar(767) DEFAULT NULL,
  `answer_B` varchar(767) DEFAULT NULL,
  `answer_C` varchar(767) DEFAULT NULL,
  `answer_D` varchar(767) DEFAULT NULL,
  `normal` tinyint(1) DEFAULT NULL,
  `Details` varchar(255) DEFAULT 'No Details'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`id`, `category`, `question`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `normal`, `Details`) VALUES
(1, 'Math', 'What is 2+2?', '8', '2', '4', '10', 1, 'Addition'),
(2, 'Math', 'What is 2*2?', '9', '4', '5', '6', 1, 'Multiplication'),
(3, 'Math', 'What is the 9 divided by 3?', '5', '7', '2', '3', 1, 'Division'),
(4, 'Math', 'What is the 10 divided by 5?', '2', '8', '9', '1', 1, 'Division'),
(5, 'Math', 'What is the 11 squared?', '99', '121', '22', '33', 1, 'Powers'),
(6, 'Breaking', 'Given a non-real circumference X of a sphere, the inverse tangent of x is inversely proportionate the natural logarithm of a tetrahedron with a base area of y. If the height of the tetrahedron is an imaginary number, and y is a representation of the derivative using the limit definition where x is undefined, compute the ratio of the density matrix of circumference X to base Y. ', ' ', ' ', ' ', ' ', 0, 'No Details'),
(7, 'Insane', 'What is the meaning of life?', 'To conform and obey to the natural cycle of chains in society.', 'To conform and obey to the natural cycle of chains in society.', 'To conform and obey to the natural cycle of chains in society.', 'To conform and obey to the natural cycle of chains in society.', 0, 'No Details'),
(8, 'Insane', 'Are men born good, evil, or neutral?', 'Evil', 'Evil', 'Evil', 'Evil', 0, 'No Details'),
(9, 'Insane', 'Does life have meaning?', 'No', 'No', 'No', 'No', 0, 'No Details'),
(10, 'Insane', 'Which is more important: Your life or a feather?', 'A feather', 'A feather', 'A feather', 'A feather', 0, 'No Details'),
(11, 'Math', 'What is 12+82?', '52', '64', '96', '94', 1, 'Addition'),
(12, 'Math', 'What is 53+9', '53', '64', '42', '62', 1, 'Addition'),
(13, 'Math', 'What is 9+0', '9', '91', '90', '10', 1, 'Addition'),
(14, 'Math', 'What is 1000 + 1000', '720', '2000', '1000', '4000', 1, 'Addition'),
(15, 'Math', 'What is 72+90', '162', '80', '18', '41', 1, 'Addition'),
(16, 'Insane', 'How does one find happiness?', 'You can\'t', 'You can\'t', 'You can\'t', 'You can\'t', 1, 'No Details'),
(17, 'Insane', 'How can a person achieve true freedom?', 'You don\'t', 'You don\'t', 'You don\'t', 'You don\'t', 0, 'No Details'),
(18, 'Math', 'What is 90 + 90', '170', '150', '180', '160', 1, 'Addition'),
(19, 'Insane', 'True/False: Murder is an act of kindness', 'True', 'True', 'True', 'True', 0, 'No Details'),
(20, 'Math', 'What is 15+90?', '105', '85', '90', '100', 1, 'Addition'),
(21, 'Math', 'What is 18+0', '18', '9', '180', '19', 1, 'Addition'),
(22, 'Nath', 'What is 70+10', '90', '70', '20', '80', 1, 'Addition'),
(23, 'Math', 'What is 42+94?', '139', '136', '159', '132', 1, 'Addition'),
(24, 'Math', 'What is 82 + 82', '30', '218', '164', '521', 1, 'Addition'),
(25, 'Math', 'What is 64+921', '129', '985', '1089', '1029', 1, 'Addition'),
(26, 'Math', 'What is 78*2', '321', '53', '156', '891', 1, 'Multiplication'),
(27, 'Math', 'What is 5*12', '60', '41', '50', '21', 1, 'Multiplication'),
(28, 'Math', 'What is 15*3', '43', '45', '21', '54', 1, 'Multiplication'),
(29, 'Math', 'What is 72*1', '72', '81', '144', '219', 1, 'Multiplication'),
(30, 'Math', 'What is 50*20?', '100', '200', '50', '25', 1, 'Multiplication'),
(31, 'Math', 'What is 81*10?', '81', '8100', '810', '8.1', 1, 'Multiplication');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`) VALUES
(1, 'Jane Doe', 'RzjR9731');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `question` (`question`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
