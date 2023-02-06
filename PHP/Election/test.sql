-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Июн 02 2020 г., 11:48
-- Версия сервера: 10.4.11-MariaDB
-- Версия PHP: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `test`
--

-- --------------------------------------------------------

--
-- Структура таблицы `closed`
--

CREATE TABLE `closed` (
  `IdClosed` bigint(20) NOT NULL,
  `IdElection` bigint(20) NOT NULL,
  `VoteCount` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `closed`
--

INSERT INTO `closed` (`IdClosed`, `IdElection`, `VoteCount`) VALUES
(28, 36, '1|2|1');

-- --------------------------------------------------------

--
-- Структура таблицы `election`
--

CREATE TABLE `election` (
  `IdElection` bigint(20) NOT NULL,
  `ElName` text NOT NULL,
  `ElType` tinyint(1) NOT NULL,
  `ElDescription` text NOT NULL,
  `StartTime` datetime NOT NULL,
  `DeadTime` datetime NOT NULL,
  `ElVariants` text NOT NULL,
  `Active` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `election`
--

INSERT INTO `election` (`IdElection`, `ElName`, `ElType`, `ElDescription`, `StartTime`, `DeadTime`, `ElVariants`, `Active`) VALUES
(36, 'asd', 1, 'asd nkar', '2020-06-02 13:23:40', '2020-06-02 13:28:40', 't1|t2|t3', 0),
(37, 'hehe', 0, 'hehe nkar', '2020-06-02 13:25:34', '2020-06-02 13:30:34', 't1|t2', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

CREATE TABLE `user` (
  `IdUser` bigint(20) NOT NULL,
  `NickName` text NOT NULL,
  `Pass` text NOT NULL,
  `Permission` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `user`
--

INSERT INTO `user` (`IdUser`, `NickName`, `Pass`, `Permission`) VALUES
(10, 'Aren', 'qwerty123', '1'),
(11, 'Eduard', 'qwerty123', '1'),
(12, 'Gago', 'qwerty123', '0'),
(13, 'Vardkes', 'qwerty123', '0'),
(14, 'Babken', 'qwerty123', '0'),
(15, 'Karbis', 'qwerty123', '0'),
(16, 'Shamir', 'qwerty123', '0'),
(17, 'Samvel', 'qwerty123', '0'),
(18, 'Albert', 'qwerty123', '0'),
(19, 'Vardan', 'qwerty123', '0'),
(20, 'Sarkis', 'qwerty123', '0'),
(21, 'Aram', 'qwerty123', '0');

-- --------------------------------------------------------

--
-- Структура таблицы `votelist`
--

CREATE TABLE `votelist` (
  `IdVoteList` bigint(20) NOT NULL,
  `IdElection` bigint(20) NOT NULL,
  `IdUser` bigint(20) NOT NULL,
  `VotedVariant` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `votelist`
--

INSERT INTO `votelist` (`IdVoteList`, `IdElection`, `IdUser`, `VotedVariant`) VALUES
(66, 36, 12, -1),
(67, 36, 15, -1),
(68, 36, 14, -1),
(69, 36, 13, -1),
(70, 37, 12, 1),
(71, 37, 15, 2),
(72, 37, 13, 1),
(73, 37, 14, 1);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `closed`
--
ALTER TABLE `closed`
  ADD PRIMARY KEY (`IdClosed`),
  ADD UNIQUE KEY `IdElection` (`IdElection`);

--
-- Индексы таблицы `election`
--
ALTER TABLE `election`
  ADD PRIMARY KEY (`IdElection`),
  ADD UNIQUE KEY `ElName` (`ElName`) USING HASH;

--
-- Индексы таблицы `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`IdUser`),
  ADD UNIQUE KEY `NickName` (`NickName`) USING HASH;

--
-- Индексы таблицы `votelist`
--
ALTER TABLE `votelist`
  ADD PRIMARY KEY (`IdVoteList`),
  ADD UNIQUE KEY `CLUSTERED` (`IdElection`,`IdUser`),
  ADD KEY `IdElection` (`IdElection`,`IdUser`),
  ADD KEY `IdUser` (`IdUser`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `closed`
--
ALTER TABLE `closed`
  MODIFY `IdClosed` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT для таблицы `election`
--
ALTER TABLE `election`
  MODIFY `IdElection` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT для таблицы `user`
--
ALTER TABLE `user`
  MODIFY `IdUser` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT для таблицы `votelist`
--
ALTER TABLE `votelist`
  MODIFY `IdVoteList` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=74;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `closed`
--
ALTER TABLE `closed`
  ADD CONSTRAINT `closed_ibfk_1` FOREIGN KEY (`IdElection`) REFERENCES `election` (`IdElection`);

--
-- Ограничения внешнего ключа таблицы `votelist`
--
ALTER TABLE `votelist`
  ADD CONSTRAINT `votelist_ibfk_1` FOREIGN KEY (`IdElection`) REFERENCES `election` (`IdElection`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `votelist_ibfk_2` FOREIGN KEY (`IdUser`) REFERENCES `user` (`IdUser`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
