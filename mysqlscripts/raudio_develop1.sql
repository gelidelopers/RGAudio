-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 30-12-2019 a las 20:08:02
-- Versión del servidor: 10.4.6-MariaDB
-- Versión de PHP: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `raudio`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_action`
--

CREATE TABLE `ra_action` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `id_tag` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_action_role`
--

CREATE TABLE `ra_action_role` (
  `id` int(11) NOT NULL,
  `id_action` int(11) NOT NULL,
  `id_role` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_artist`
--

CREATE TABLE `ra_artist` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ra_artist`
--

INSERT INTO `ra_artist` (`id`, `name`) VALUES
(1, 'Avicii'),
(2, 'Coldplay'),
(4, 'Dire Straits'),
(3, 'Pink Floyd'),
(5, 'Queen');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_audio`
--

CREATE TABLE `ra_audio` (
  `id` int(11) NOT NULL,
  `filename` int(11) NOT NULL,
  `extension` varchar(6) NOT NULL,
  `id_folder` int(11) NOT NULL,
  `id_audio_type` int(11) NOT NULL,
  `name` varchar(4000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_audio_fav`
--

CREATE TABLE `ra_audio_fav` (
  `id` int(11) NOT NULL,
  `id_audio` int(11) NOT NULL,
  `id_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_audio_version`
--

CREATE TABLE `ra_audio_version` (
  `id` int(11) NOT NULL,
  `id_audio` int(11) NOT NULL,
  `versionnumber` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_contact`
--

CREATE TABLE `ra_contact` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `middlename` int(30) DEFAULT NULL,
  `lastname` int(30) DEFAULT NULL,
  `email` varchar(40) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` varchar(120) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ra_contact`
--

INSERT INTO `ra_contact` (`id`, `name`, `middlename`, `lastname`, `email`, `phone`, `address`) VALUES
(7, 'test', NULL, NULL, NULL, NULL, NULL),
(8, 'test', NULL, NULL, NULL, NULL, NULL),
(10, 'test', NULL, NULL, NULL, NULL, NULL),
(11, 'test', NULL, NULL, NULL, NULL, NULL),
(12, 'test', NULL, NULL, NULL, NULL, NULL),
(13, 'test', NULL, NULL, NULL, NULL, NULL),
(14, 'test', NULL, NULL, NULL, NULL, NULL),
(15, 'test', NULL, NULL, NULL, NULL, NULL),
(16, 'test', NULL, NULL, NULL, NULL, NULL),
(17, 'test', NULL, NULL, NULL, NULL, NULL),
(18, 'test', NULL, NULL, NULL, NULL, NULL),
(19, 'test', NULL, NULL, NULL, NULL, NULL),
(21, 'test', NULL, NULL, NULL, NULL, NULL),
(22, 'test', NULL, NULL, NULL, NULL, NULL),
(24, 'test', NULL, NULL, NULL, NULL, NULL),
(25, 'test', NULL, NULL, NULL, NULL, NULL),
(26, 'test', NULL, NULL, NULL, NULL, NULL),
(27, 'test', NULL, NULL, NULL, NULL, NULL),
(28, 'test', NULL, NULL, NULL, NULL, NULL),
(29, 'test', NULL, NULL, NULL, NULL, NULL),
(30, 'test', NULL, NULL, NULL, NULL, NULL),
(31, 'test', NULL, NULL, NULL, NULL, NULL),
(32, 'test', NULL, NULL, NULL, NULL, NULL),
(33, 'test', NULL, NULL, NULL, NULL, NULL),
(34, 'test', NULL, NULL, NULL, NULL, NULL),
(35, 'test', NULL, NULL, NULL, NULL, NULL),
(36, 'test', NULL, NULL, NULL, NULL, NULL),
(37, 'test', NULL, NULL, NULL, NULL, NULL),
(38, 'test', NULL, NULL, NULL, NULL, NULL),
(39, 'test', NULL, NULL, NULL, NULL, NULL),
(40, 'test', NULL, NULL, NULL, NULL, NULL),
(41, 'test', NULL, NULL, NULL, NULL, NULL),
(42, 'test', NULL, NULL, NULL, NULL, NULL),
(43, 'test', NULL, NULL, NULL, NULL, NULL),
(44, 'test', NULL, NULL, NULL, NULL, NULL),
(45, 'test', NULL, NULL, NULL, NULL, NULL),
(46, 'test', NULL, NULL, NULL, NULL, NULL),
(47, 'test', NULL, NULL, NULL, NULL, NULL),
(48, 'test', NULL, NULL, NULL, NULL, NULL),
(49, 'test', NULL, NULL, NULL, NULL, NULL),
(50, 'test', NULL, NULL, NULL, NULL, NULL),
(51, 'test', NULL, NULL, NULL, NULL, NULL),
(52, 'test', NULL, NULL, NULL, NULL, NULL),
(53, 'test', NULL, NULL, NULL, NULL, NULL),
(54, 'test', NULL, NULL, NULL, NULL, NULL),
(55, 'test', NULL, NULL, NULL, NULL, NULL),
(56, 'test', NULL, NULL, NULL, NULL, NULL),
(57, 'test', NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_device`
--

CREATE TABLE `ra_device` (
  `id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL,
  `firstconnection` timestamp NULL DEFAULT NULL,
  `lastconnection` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_entity`
--

CREATE TABLE `ra_entity` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `id_tag` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_folder`
--

CREATE TABLE `ra_folder` (
  `id` int(11) NOT NULL,
  `id_device` int(11) NOT NULL,
  `directory` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_genre`
--

CREATE TABLE `ra_genre` (
  `id` int(11) NOT NULL,
  `name` int(11) NOT NULL,
  `id_parent` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_info`
--

CREATE TABLE `ra_info` (
  `id` tinyint(3) UNSIGNED NOT NULL,
  `name` varchar(50) NOT NULL,
  `value` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ra_info`
--

INSERT INTO `ra_info` (`id`, `name`, `value`) VALUES
(1, 'databaseversion', 'develop1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_lang`
--

CREATE TABLE `ra_lang` (
  `id` int(11) NOT NULL,
  `code` varchar(5) NOT NULL,
  `name` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ra_lang`
--

INSERT INTO `ra_lang` (`id`, `code`, `name`) VALUES
(1, 'ca-ES', 'Català');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_podcast`
--

CREATE TABLE `ra_podcast` (
  `id` int(11) NOT NULL,
  `id_show` int(11) NOT NULL,
  `number` int(11) NOT NULL,
  `publishdate` timestamp NULL DEFAULT NULL,
  `id_audio` int(11) NOT NULL,
  `ontheweb` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_roles`
--

CREATE TABLE `ra_roles` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `id_tag` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_show`
--

CREATE TABLE `ra_show` (
  `id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_show_audio`
--

CREATE TABLE `ra_show_audio` (
  `id` int(11) NOT NULL,
  `id_audio` int(11) NOT NULL,
  `id_show` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_song`
--

CREATE TABLE `ra_song` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `id_artist` int(11) DEFAULT NULL,
  `id_album` int(11) DEFAULT NULL,
  `id_audio` int(11) NOT NULL,
  `duration` time NOT NULL,
  `id_genre` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_song_artist`
--

CREATE TABLE `ra_song_artist` (
  `id` int(11) NOT NULL,
  `id_song` int(11) NOT NULL,
  `id_artist` int(11) NOT NULL,
  `num` tinyint(2) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_tag`
--

CREATE TABLE `ra_tag` (
  `id` int(11) NOT NULL,
  `code` varchar(50) NOT NULL,
  `description` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ra_tag`
--

INSERT INTO `ra_tag` (`id`, `code`, `description`) VALUES
(1, 'web.login.enter', '0');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_translations`
--

CREATE TABLE `ra_translations` (
  `id` int(11) NOT NULL,
  `id_tag` int(11) NOT NULL,
  `id_lang` int(11) NOT NULL,
  `value` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ra_translations`
--

INSERT INTO `ra_translations` (`id`, `id_tag`, `id_lang`, `value`) VALUES
(1, 1, 1, 'Entrar');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_user`
--

CREATE TABLE `ra_user` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `password` varchar(255) NOT NULL,
  `mail` tinytext DEFAULT NULL,
  `id_persona` int(11) DEFAULT NULL,
  `lang` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ra_user`
--

INSERT INTO `ra_user` (`id`, `name`, `password`, `mail`, `id_persona`, `lang`) VALUES
(1, 'xavi', '827ccb0eea8a706c4c34a16891f84e7b', NULL, NULL, NULL),
(2, 'admin', '$2y$10$JqyvNEvLm80ze5X6tpRmHuuHvMHrmFlQ3EkBn9ZnSrvbf27IaFUvC', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ra_user_role`
--

CREATE TABLE `ra_user_role` (
  `id` int(11) NOT NULL,
  `id_user` int(11) NOT NULL,
  `id_role` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `ra_action`
--
ALTER TABLE `ra_action`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_action_tag_fk` (`id_tag`);

--
-- Indices de la tabla `ra_action_role`
--
ALTER TABLE `ra_action_role`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_action_role_action_fk` (`id_action`),
  ADD KEY `ra_action_role_role_fk` (`id_role`);

--
-- Indices de la tabla `ra_artist`
--
ALTER TABLE `ra_artist`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indices de la tabla `ra_audio`
--
ALTER TABLE `ra_audio`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_audio_folder_fk` (`id_folder`),
  ADD KEY `audio_name_index` (`name`(1024));

--
-- Indices de la tabla `ra_audio_fav`
--
ALTER TABLE `ra_audio_fav`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_audio_fav_audio_fk` (`id_audio`),
  ADD KEY `ra_audio_fav_user_fk` (`id_user`);

--
-- Indices de la tabla `ra_audio_version`
--
ALTER TABLE `ra_audio_version`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_audio_version_fk` (`id_audio`);

--
-- Indices de la tabla `ra_contact`
--
ALTER TABLE `ra_contact`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `ra_device`
--
ALTER TABLE `ra_device`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `ra_entity`
--
ALTER TABLE `ra_entity`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_entity_tag_fk` (`id_tag`);

--
-- Indices de la tabla `ra_folder`
--
ALTER TABLE `ra_folder`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_folder_device_fk` (`id_device`);

--
-- Indices de la tabla `ra_genre`
--
ALTER TABLE `ra_genre`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `ra_genre_name_uk` (`name`) USING BTREE,
  ADD KEY `ra_genre_parent_rk` (`id_parent`);

--
-- Indices de la tabla `ra_info`
--
ALTER TABLE `ra_info`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `info_name_unique` (`name`);

--
-- Indices de la tabla `ra_lang`
--
ALTER TABLE `ra_lang`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `code` (`code`);

--
-- Indices de la tabla `ra_podcast`
--
ALTER TABLE `ra_podcast`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_podcast_show_fk` (`id_show`),
  ADD KEY `ra_podcast_audio_fk` (`id_audio`);

--
-- Indices de la tabla `ra_roles`
--
ALTER TABLE `ra_roles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_roles_tag_fk` (`id_tag`);

--
-- Indices de la tabla `ra_show`
--
ALTER TABLE `ra_show`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indices de la tabla `ra_show_audio`
--
ALTER TABLE `ra_show_audio`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_show_audio_audio_fk` (`id_audio`),
  ADD KEY `ra_show_audio_show_fk` (`id_show`);

--
-- Indices de la tabla `ra_song`
--
ALTER TABLE `ra_song`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_song_audio_fk` (`id_audio`),
  ADD KEY `ra_song_name_index` (`id`),
  ADD KEY `ra_song_genre_fk` (`id_genre`);

--
-- Indices de la tabla `ra_song_artist`
--
ALTER TABLE `ra_song_artist`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ra_song_artist_artist_fk` (`id_artist`),
  ADD KEY `ra_song_artist_song_fk` (`id_song`);

--
-- Indices de la tabla `ra_tag`
--
ALTER TABLE `ra_tag`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `ra_translations`
--
ALTER TABLE `ra_translations`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unique_tag_lang` (`id_tag`,`id_lang`),
  ADD KEY `translation_lang_fk` (`id_lang`);

--
-- Indices de la tabla `ra_user`
--
ALTER TABLE `ra_user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `ra_user_unique` (`id`),
  ADD KEY `ra_user_persona_fk` (`id_persona`);

--
-- Indices de la tabla `ra_user_role`
--
ALTER TABLE `ra_user_role`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_user` (`id_user`,`id_role`),
  ADD KEY `ra_user_role_role_fk` (`id_role`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `ra_action`
--
ALTER TABLE `ra_action`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_action_role`
--
ALTER TABLE `ra_action_role`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_artist`
--
ALTER TABLE `ra_artist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `ra_audio`
--
ALTER TABLE `ra_audio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_audio_fav`
--
ALTER TABLE `ra_audio_fav`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_audio_version`
--
ALTER TABLE `ra_audio_version`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_contact`
--
ALTER TABLE `ra_contact`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=58;

--
-- AUTO_INCREMENT de la tabla `ra_device`
--
ALTER TABLE `ra_device`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_entity`
--
ALTER TABLE `ra_entity`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_folder`
--
ALTER TABLE `ra_folder`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_genre`
--
ALTER TABLE `ra_genre`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_info`
--
ALTER TABLE `ra_info`
  MODIFY `id` tinyint(3) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `ra_lang`
--
ALTER TABLE `ra_lang`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `ra_podcast`
--
ALTER TABLE `ra_podcast`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_roles`
--
ALTER TABLE `ra_roles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_show`
--
ALTER TABLE `ra_show`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_show_audio`
--
ALTER TABLE `ra_show_audio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_song`
--
ALTER TABLE `ra_song`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_song_artist`
--
ALTER TABLE `ra_song_artist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ra_tag`
--
ALTER TABLE `ra_tag`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `ra_translations`
--
ALTER TABLE `ra_translations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `ra_user`
--
ALTER TABLE `ra_user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `ra_user_role`
--
ALTER TABLE `ra_user_role`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `ra_action`
--
ALTER TABLE `ra_action`
  ADD CONSTRAINT `ra_action_tag_fk` FOREIGN KEY (`id_tag`) REFERENCES `ra_tag` (`id`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Filtros para la tabla `ra_action_role`
--
ALTER TABLE `ra_action_role`
  ADD CONSTRAINT `ra_action_role_action_fk` FOREIGN KEY (`id_action`) REFERENCES `ra_action` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ra_action_role_role_fk` FOREIGN KEY (`id_role`) REFERENCES `ra_roles` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `ra_audio`
--
ALTER TABLE `ra_audio`
  ADD CONSTRAINT `ra_audio_folder_fk` FOREIGN KEY (`id_folder`) REFERENCES `ra_folder` (`id`);

--
-- Filtros para la tabla `ra_audio_fav`
--
ALTER TABLE `ra_audio_fav`
  ADD CONSTRAINT `ra_audio_fav_audio_fk` FOREIGN KEY (`id_audio`) REFERENCES `ra_audio` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ra_audio_fav_user_fk` FOREIGN KEY (`id_user`) REFERENCES `ra_user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `ra_audio_version`
--
ALTER TABLE `ra_audio_version`
  ADD CONSTRAINT `ra_audio_version_fk` FOREIGN KEY (`id_audio`) REFERENCES `ra_audio` (`id`);

--
-- Filtros para la tabla `ra_entity`
--
ALTER TABLE `ra_entity`
  ADD CONSTRAINT `ra_entity_tag_fk` FOREIGN KEY (`id_tag`) REFERENCES `ra_tag` (`id`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Filtros para la tabla `ra_folder`
--
ALTER TABLE `ra_folder`
  ADD CONSTRAINT `ra_folder_device_fk` FOREIGN KEY (`id_device`) REFERENCES `ra_device` (`id`);

--
-- Filtros para la tabla `ra_genre`
--
ALTER TABLE `ra_genre`
  ADD CONSTRAINT `ra_genre_parent_rk` FOREIGN KEY (`id_parent`) REFERENCES `ra_genre` (`id`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Filtros para la tabla `ra_podcast`
--
ALTER TABLE `ra_podcast`
  ADD CONSTRAINT `ra_podcast_audio_fk` FOREIGN KEY (`id_audio`) REFERENCES `ra_audio` (`id`),
  ADD CONSTRAINT `ra_podcast_show_fk` FOREIGN KEY (`id_show`) REFERENCES `ra_show` (`id`);

--
-- Filtros para la tabla `ra_roles`
--
ALTER TABLE `ra_roles`
  ADD CONSTRAINT `ra_roles_tag_fk` FOREIGN KEY (`id_tag`) REFERENCES `ra_tag` (`id`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Filtros para la tabla `ra_show_audio`
--
ALTER TABLE `ra_show_audio`
  ADD CONSTRAINT `ra_show_audio_audio_fk` FOREIGN KEY (`id_audio`) REFERENCES `ra_audio` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ra_show_audio_show_fk` FOREIGN KEY (`id_show`) REFERENCES `ra_show` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `ra_song`
--
ALTER TABLE `ra_song`
  ADD CONSTRAINT `ra_song_audio_fk` FOREIGN KEY (`id_audio`) REFERENCES `ra_audio` (`id`),
  ADD CONSTRAINT `ra_song_genre_fk` FOREIGN KEY (`id_genre`) REFERENCES `ra_genre` (`id`);

--
-- Filtros para la tabla `ra_song_artist`
--
ALTER TABLE `ra_song_artist`
  ADD CONSTRAINT `ra_song_artist_artist_fk` FOREIGN KEY (`id_artist`) REFERENCES `ra_artist` (`id`),
  ADD CONSTRAINT `ra_song_artist_song_fk` FOREIGN KEY (`id_song`) REFERENCES `ra_song` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `ra_translations`
--
ALTER TABLE `ra_translations`
  ADD CONSTRAINT `translation_lang_fk` FOREIGN KEY (`id_lang`) REFERENCES `ra_lang` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `translation_tag_fk` FOREIGN KEY (`id_tag`) REFERENCES `ra_tag` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `ra_user`
--
ALTER TABLE `ra_user`
  ADD CONSTRAINT `ra_user_persona_fk` FOREIGN KEY (`id_persona`) REFERENCES `ra_contact` (`id`);

--
-- Filtros para la tabla `ra_user_role`
--
ALTER TABLE `ra_user_role`
  ADD CONSTRAINT `ra_user_role_role_fk` FOREIGN KEY (`id_role`) REFERENCES `ra_roles` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ra_user_role_user_fk` FOREIGN KEY (`id_user`) REFERENCES `ra_user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
