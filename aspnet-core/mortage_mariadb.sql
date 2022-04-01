q-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.7.3-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------
-- Dumping database structure for mortgagedb
CREATE DATABASE IF NOT EXISTS `mortgagedb` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `mortgagedb`;

-- Dumping structure for table mortgagedb.applications
CREATE TABLE IF NOT EXISTS `applications` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DATE` datetime(3) NOT NULL,
  `LOAN NO_IDENTIFIER_B1_B3` varchar(15) CHARACTER SET utf8mb3 NOT NULL,
  `AGENCY_CASE_NO_B2` varchar(15) CHARACTER SET utf8mb3 NOT NULL,
  `CREDIT_TYPE_ID` int(11) NOT NULL,
  `TOTAL_BORROWERS_1A.6` int(11) DEFAULT NULL,
  `INITIALS` varchar(10) CHARACTER SET utf8mb3 DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `CREDIT_TYPE_ID` (`CREDIT_TYPE_ID`),
  CONSTRAINT `applications_ibfk_1` FOREIGN KEY (`CREDIT_TYPE_ID`) REFERENCES `credit_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_additional_employement_details
CREATE TABLE IF NOT EXISTS `application_additional_employement_details` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `EMPLOYER/BUSINESS_NAME` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `PHONE` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `STREET` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `UNIT` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ZIP` varchar(10) CHARACTER SET utf8mb3 DEFAULT NULL,
  `COUNTRY_ID` int(11) NOT NULL,
  `STATE_ID` int(11) NOT NULL,
  `CITY_ID` int(11) NOT NULL,
  `POSITION_TITLE` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `START_DATE` datetime DEFAULT NULL,
  `WORKING_YEARS` int(11) DEFAULT NULL,
  `WORKING_MONTHS` int(11) DEFAULT NULL,
  `IS_EMPLOYED_BY_SOMEONE` bit(1) DEFAULT NULL,
  `IS_SELF_EMPLOYED` bit(1) DEFAULT NULL,
  `IS_OWNERSHIP_LESS_THAN_25` bit(1) DEFAULT NULL,
  `MONTHLY_INCOME` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `COUNTRY_ID` (`COUNTRY_ID`),
  KEY `STATE_ID` (`STATE_ID`),
  KEY `CITY_ID` (`CITY_ID`),
  CONSTRAINT `application_additional_employement_details_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `application_additional_employement_details_ibfk_2` FOREIGN KEY (`COUNTRY_ID`) REFERENCES `countries` (`ID`),
  CONSTRAINT `application_additional_employement_details_ibfk_3` FOREIGN KEY (`STATE_ID`) REFERENCES `states` (`ID`),
  CONSTRAINT `application_additional_employement_details_ibfk_4` FOREIGN KEY (`CITY_ID`) REFERENCES `cities` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_additional_employement_income_details
CREATE TABLE IF NOT EXISTS `application_additional_employement_income_details` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_ADDITIONAL_EMPLOYEMENT_DETAILS` int(11) NOT NULL,
  `INCOME_TYPE_ID` int(11) NOT NULL,
  `AMOUNT` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_ADDITIONAL_EMPLOYEMENT_DETAILS` (`APPLICATION_ADDITIONAL_EMPLOYEMENT_DETAILS`),
  KEY `INCOME_TYPE_ID` (`INCOME_TYPE_ID`),
  CONSTRAINT `application_additional_employement_income_details_ibfk_1` FOREIGN KEY (`APPLICATION_ADDITIONAL_EMPLOYEMENT_DETAILS`) REFERENCES `application_additional_employement_details` (`ID`),
  CONSTRAINT `application_additional_employement_income_details_ibfk_2` FOREIGN KEY (`INCOME_TYPE_ID`) REFERENCES `income_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_declaration_questions
CREATE TABLE IF NOT EXISTS `application_declaration_questions` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `DECLARATION_QUESTION_ID` int(11) DEFAULT NULL,
  `YES_NO` bit(1) DEFAULT NULL,
  `DESCRIPTION_5A` varchar(500) CHARACTER SET utf8mb3 DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `DECLARATION_QUESTION_ID` (`DECLARATION_QUESTION_ID`),
  CONSTRAINT `application_declaration_questions_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `application_declaration_questions_ibfk_2` FOREIGN KEY (`DECLARATION_QUESTION_ID`) REFERENCES `declaration_questions` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_employement_details
CREATE TABLE IF NOT EXISTS `application_employement_details` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `EMPLOYER/BUSINESS_NAME_1B.2` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `PHONE_1B.3` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `STREET_1B.4.1` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `UNIT_1B.4.2` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ZIP_1B.4.5` varchar(10) CHARACTER SET utf8mb3 DEFAULT NULL,
  `COUNTRY_ID_1B.4.6` int(11) NOT NULL,
  `STATE_ID_1B.4.4` int(11) NOT NULL,
  `CITY_ID_1B.4.3` int(11) NOT NULL,
  `POSITION_TITLE_1B.5` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `START_DATE_1B.6` datetime DEFAULT NULL,
  `WORKING_YEARS_1B.7` int(11) DEFAULT NULL,
  `WORKING_MONTHS` int(11) DEFAULT NULL,
  `IS_EMPLOYED_BY_SOMEONE_1B.8` bit(1) DEFAULT NULL,
  `IS_SELF_EMPLOYED_1B.9` bit(1) DEFAULT NULL,
  `IS_OWNERSHIP_LESS_THAN_25_1B.9.1` bit(1) DEFAULT NULL,
  `MONTHLY_INCOME_1B.9.2` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `COUNTRY_ID_1B.4.6` (`COUNTRY_ID_1B.4.6`),
  KEY `STATE_ID_1B.4.4` (`STATE_ID_1B.4.4`),
  KEY `CITY_ID_1B.4.3` (`CITY_ID_1B.4.3`),
  CONSTRAINT `application_employement_details_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `application_employement_details_ibfk_2` FOREIGN KEY (`COUNTRY_ID_1B.4.6`) REFERENCES `countries` (`ID`),
  CONSTRAINT `application_employement_details_ibfk_3` FOREIGN KEY (`STATE_ID_1B.4.4`) REFERENCES `states` (`ID`),
  CONSTRAINT `application_employement_details_ibfk_4` FOREIGN KEY (`CITY_ID_1B.4.3`) REFERENCES `cities` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_employement_income_details
CREATE TABLE IF NOT EXISTS `application_employement_income_details` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_EMPLOYEMENT_DETAILS_ID` int(11) NOT NULL,
  `INCOME_TYPE_ID_1B.10.1` int(11) NOT NULL,
  `AMOUNT_1B.10` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_EMPLOYEMENT_DETAILS_ID` (`APPLICATION_EMPLOYEMENT_DETAILS_ID`),
  KEY `INCOME_TYPE_ID_1B.10.1` (`INCOME_TYPE_ID_1B.10.1`),
  CONSTRAINT `application_employement_income_details_ibfk_1` FOREIGN KEY (`APPLICATION_EMPLOYEMENT_DETAILS_ID`) REFERENCES `application_employement_details` (`ID`),
  CONSTRAINT `application_employement_income_details_ibfk_2` FOREIGN KEY (`INCOME_TYPE_ID_1B.10.1`) REFERENCES `income_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_financial_assets
CREATE TABLE IF NOT EXISTS `application_financial_assets` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `FINANCIAL_ACCOUNT_TYPE_ID_2A.1` int(11) NOT NULL,
  `FINANCIAL_INSTITUTION_2A.2` varchar(50) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ACCOUNT_NUMBER_2A.3` varchar(50) CHARACTER SET utf8mb3 DEFAULT NULL,
  `VALUE_2A.4` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `FINANCIAL_ACCOUNT_TYPE_ID_2A.1` (`FINANCIAL_ACCOUNT_TYPE_ID_2A.1`),
  CONSTRAINT `application_financial_assets_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `application_financial_assets_ibfk_2` FOREIGN KEY (`FINANCIAL_ACCOUNT_TYPE_ID_2A.1`) REFERENCES `financial_account_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_financial_laibilities
CREATE TABLE IF NOT EXISTS `application_financial_laibilities` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `FINANCIAL_LAIBILITIES_TYPE_2C.1` int(11) NOT NULL,
  `COMPANY_NAME_2C.2` varchar(50) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ACCOUNT_NUMBER_2C.3` varchar(50) CHARACTER SET utf8mb3 DEFAULT NULL,
  `UNPAID_BALANCE_2C.4` float DEFAULT NULL,
  `PAID_OFF_2C.5` bit(1) DEFAULT NULL,
  `MONTHLY_VALUE_2C.6` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `FINANCIAL_LAIBILITIES_TYPE_2C.1` (`FINANCIAL_LAIBILITIES_TYPE_2C.1`),
  CONSTRAINT `application_financial_laibilities_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `application_financial_laibilities_ibfk_2` FOREIGN KEY (`FINANCIAL_LAIBILITIES_TYPE_2C.1`) REFERENCES `financial_laibilities_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_financial_other_assets
CREATE TABLE IF NOT EXISTS `application_financial_other_assets` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `FINANCIAL_ASSETS_TYPES_ID_2B.1` int(11) NOT NULL,
  `VALUE_2B.2` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `FINANCIAL_ASSETS_TYPES_ID_2B.1` (`FINANCIAL_ASSETS_TYPES_ID_2B.1`),
  CONSTRAINT `application_financial_other_assets_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `application_financial_other_assets_ibfk_2` FOREIGN KEY (`FINANCIAL_ASSETS_TYPES_ID_2B.1`) REFERENCES `financial_assets_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_financial_other_laibilities
CREATE TABLE IF NOT EXISTS `application_financial_other_laibilities` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D.1` int(11) NOT NULL,
  `MONTHLY_PAYMENT_2D.2` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D.1` (`FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D.1`),
  CONSTRAINT `application_financial_other_laibilities_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `application_financial_other_laibilities_ibfk_2` FOREIGN KEY (`FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D.1`) REFERENCES `financial_other_laibilities_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_financial_real_estate
CREATE TABLE IF NOT EXISTS `application_financial_real_estate` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `STREET_3A.2.1` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  `UNIT_NO_3A.2.2` varchar(10) CHARACTER SET utf8mb3 NOT NULL,
  `ZIP_3A.2.5` varchar(10) CHARACTER SET utf8mb3 NOT NULL,
  `COUNTRY_ID_3A.2.6` int(11) NOT NULL,
  `STATE_ID_3A.2.4` int(11) NOT NULL,
  `CITY_ID_3A.2.3` int(11) NOT NULL,
  `PROPERTY_VALUE_3A.3` float DEFAULT NULL,
  `FINANCIAL_PROPERTY_STATUS_ID_3A.4` int(11) NOT NULL,
  `FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A.5` int(11) NOT NULL,
  `MONTHLY_MORTAGE_PAYMENT_3A.6` float DEFAULT NULL,
  `MONTHLY_RENTAL_INCOME_3A.7` float DEFAULT NULL,
  `NET_MONTHLY_RENTAL_INCOME_3A.8` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `COUNTRY_ID_3A.2.6` (`COUNTRY_ID_3A.2.6`),
  KEY `STATE_ID_3A.2.4` (`STATE_ID_3A.2.4`),
  KEY `CITY_ID_3A.2.3` (`CITY_ID_3A.2.3`),
  KEY `FINANCIAL_PROPERTY_STATUS_ID_3A.4` (`FINANCIAL_PROPERTY_STATUS_ID_3A.4`),
  KEY `FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A.5` (`FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A.5`),
  CONSTRAINT `application_financial_real_estate_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `application_financial_real_estate_ibfk_2` FOREIGN KEY (`COUNTRY_ID_3A.2.6`) REFERENCES `countries` (`ID`),
  CONSTRAINT `application_financial_real_estate_ibfk_3` FOREIGN KEY (`STATE_ID_3A.2.4`) REFERENCES `states` (`ID`),
  CONSTRAINT `application_financial_real_estate_ibfk_4` FOREIGN KEY (`CITY_ID_3A.2.3`) REFERENCES `cities` (`ID`),
  CONSTRAINT `application_financial_real_estate_ibfk_5` FOREIGN KEY (`FINANCIAL_PROPERTY_STATUS_ID_3A.4`) REFERENCES `financial_property_status` (`ID`),
  CONSTRAINT `application_financial_real_estate_ibfk_6` FOREIGN KEY (`FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A.5`) REFERENCES `financial_property_intended_occupancies` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_income_sources
CREATE TABLE IF NOT EXISTS `application_income_sources` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `INCOME_SOURCE_ID_1E.1` int(11) NOT NULL,
  `AMOUNT_1E.2` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `INCOME_SOURCE_ID_1E.1` (`INCOME_SOURCE_ID_1E.1`),
  CONSTRAINT `application_income_sources_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `application_income_sources_ibfk_2` FOREIGN KEY (`INCOME_SOURCE_ID_1E.1`) REFERENCES `income_sources` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_personal_information
CREATE TABLE IF NOT EXISTS `application_personal_information` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_ID` int(11) NOT NULL,
  `FIRST_NAME_1A.1` varchar(200) CHARACTER SET utf8mb3 DEFAULT NULL,
  `MIDDLE_NAME_1A.2` varchar(200) CHARACTER SET utf8mb3 DEFAULT NULL,
  `LAST_NAME_1A.3` varchar(200) CHARACTER SET utf8mb3 DEFAULT NULL,
  `SUFFIX_1A.4` varchar(200) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ALTERNATE_FIRST_NAME_1A.2.1` varchar(200) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ALTERNATE_MIDDLE_NAME_1A.2.2` varchar(200) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ALTERNATE_LAST_NAME_1A.2.3` varchar(200) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ALTERNATE_SUFFIX_1A.2.4` varchar(200) CHARACTER SET utf8mb3 DEFAULT NULL,
  `SSN_1A.3` varchar(50) CHARACTER SET utf8mb3 DEFAULT NULL,
  `DOB_1A.4` datetime DEFAULT NULL,
  `CITIZENSHIP_TYPE_ID_1A.5` int(11) NOT NULL,
  `MARITIAL_STATUS_ID_1A.7` int(11) NOT NULL,
  `DEPENDENTS_1A.8` int(11) DEFAULT NULL,
  `AGES_1A.8.1` varchar(50) CHARACTER SET utf8mb3 DEFAULT NULL,
  `HOME_PHONE_1A.9` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `CELL_PHONE_1A.10` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `WORK_PHONE_1A.11` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `EXT_1A.11.1` varchar(5) CHARACTER SET utf8mb3 DEFAULT NULL,
  `EMAIL_1A.12` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `CURRENT_STREET_1A.13.1` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `CURRENT_UNIT_1A.13.2` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `CURRENT_ZIP_1A.13.5` varchar(10) CHARACTER SET utf8mb3 DEFAULT NULL,
  `CURRENT_COUNTRY_ID_1A.13.6` int(11) NOT NULL,
  `CURRENT_STATE_ID_1A.13.4` int(11) NOT NULL,
  `CURRENT_CITY_ID_1A.13.3` int(11) NOT NULL,
  `CURRENT_YEARS_1A.14` int(11) DEFAULT NULL,
  `CURRENT_MONTHS_1A.15` int(11) DEFAULT NULL,
  `CURRENT_HOUSING_TYPE_ID_1A.14.1` int(11) NOT NULL,
  `CURRENT_RENT_1A.14.2` float DEFAULT NULL,
  `FORMER_STREET_1A.15.1` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `FORMER_UNIT_1A.15.2` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `FORMER_ZIP_1A.15.5` varchar(10) CHARACTER SET utf8mb3 DEFAULT NULL,
  `FORMER_COUNTRY_ID_1A.15.6` int(11) NOT NULL,
  `FORMER_STATE_ID_1A.15.4` int(11) NOT NULL,
  `FORMER_CITY_ID_1A.15.3` int(11) NOT NULL,
  `FORMER_YEARS_1A.16` int(11) DEFAULT NULL,
  `FORMER_MONTHS_1A.16.1` int(11) DEFAULT NULL,
  `FORMER_HOUSING_TYPE_ID_1A.16.1` int(11) NOT NULL,
  `FORMER_RENT_1A.16.2` float DEFAULT NULL,
  `MAILING_STREET_1A.17.1` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `MAILING_UNIT_1A.17.2` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `MAILING_ZIP_1A.17.5` varchar(10) CHARACTER SET utf8mb3 DEFAULT NULL,
  `MAILING_COUNTRY_ID_1A.17.6` int(11) NOT NULL,
  `MAILING_STATE_ID_1A.17.4` int(11) NOT NULL,
  `MAILING_CITY_ID_1A.17.3` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_ID` (`APPLICATION_ID`),
  KEY `CITIZENSHIP_TYPE_ID_1A.5` (`CITIZENSHIP_TYPE_ID_1A.5`),
  KEY `MARITIAL_STATUS_ID_1A.7` (`MARITIAL_STATUS_ID_1A.7`),
  KEY `CURRENT_COUNTRY_ID_1A.13.6` (`CURRENT_COUNTRY_ID_1A.13.6`),
  KEY `CURRENT_STATE_ID_1A.13.4` (`CURRENT_STATE_ID_1A.13.4`),
  KEY `CURRENT_CITY_ID_1A.13.3` (`CURRENT_CITY_ID_1A.13.3`),
  KEY `CURRENT_HOUSING_TYPE_ID_1A.14.1` (`CURRENT_HOUSING_TYPE_ID_1A.14.1`),
  KEY `FORMER_COUNTRY_ID_1A.15.6` (`FORMER_COUNTRY_ID_1A.15.6`),
  KEY `FORMER_STATE_ID_1A.15.4` (`FORMER_STATE_ID_1A.15.4`),
  KEY `FORMER_CITY_ID_1A.15.3` (`FORMER_CITY_ID_1A.15.3`),
  KEY `FORMER_HOUSING_TYPE_ID_1A.16.1` (`FORMER_HOUSING_TYPE_ID_1A.16.1`),
  KEY `MAILING_COUNTRY_ID_1A.17.6` (`MAILING_COUNTRY_ID_1A.17.6`),
  KEY `MAILING_STATE_ID_1A.17.4` (`MAILING_STATE_ID_1A.17.4`),
  KEY `MAILING_CITY_ID_1A.17.3` (`MAILING_CITY_ID_1A.17.3`),
  CONSTRAINT `application_personal_information_ibfk_1` FOREIGN KEY (`APPLICATION_ID`) REFERENCES `applications` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_10` FOREIGN KEY (`FORMER_CITY_ID_1A.15.3`) REFERENCES `cities` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_11` FOREIGN KEY (`FORMER_HOUSING_TYPE_ID_1A.16.1`) REFERENCES `housing_types` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_12` FOREIGN KEY (`MAILING_COUNTRY_ID_1A.17.6`) REFERENCES `countries` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_13` FOREIGN KEY (`MAILING_STATE_ID_1A.17.4`) REFERENCES `states` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_14` FOREIGN KEY (`MAILING_CITY_ID_1A.17.3`) REFERENCES `cities` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_2` FOREIGN KEY (`CITIZENSHIP_TYPE_ID_1A.5`) REFERENCES `citizenship_types` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_3` FOREIGN KEY (`MARITIAL_STATUS_ID_1A.7`) REFERENCES `maritial_status` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_4` FOREIGN KEY (`CURRENT_COUNTRY_ID_1A.13.6`) REFERENCES `countries` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_5` FOREIGN KEY (`CURRENT_STATE_ID_1A.13.4`) REFERENCES `states` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_6` FOREIGN KEY (`CURRENT_CITY_ID_1A.13.3`) REFERENCES `cities` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_7` FOREIGN KEY (`CURRENT_HOUSING_TYPE_ID_1A.14.1`) REFERENCES `housing_types` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_8` FOREIGN KEY (`FORMER_COUNTRY_ID_1A.15.6`) REFERENCES `countries` (`ID`),
  CONSTRAINT `application_personal_information_ibfk_9` FOREIGN KEY (`FORMER_STATE_ID_1A.15.4`) REFERENCES `states` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.application_previous_employement_details
CREATE TABLE IF NOT EXISTS `application_previous_employement_details` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `EMPLOYER/BUSINESS_NAME_1D.2` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `STREET_1D.3.1` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `UNIT_1D.3.2` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ZIP_1D.3.5` varchar(10) CHARACTER SET utf8mb3 DEFAULT NULL,
  `COUNTRY_ID_1D.3.6` int(11) NOT NULL,
  `STATE_ID_1D.3.4` int(11) NOT NULL,
  `CITY_ID_1D.3.3` int(11) NOT NULL,
  `POSITION_TITLE_1D.4` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `START_DATE_1D.5` datetime DEFAULT NULL,
  `END_DATE_1D.6` datetime DEFAULT NULL,
  `IS_SELF_EMPLOYED_1D.7` bit(1) DEFAULT NULL,
  `GROSS_MONTHLY_INCOME_1D.8` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `COUNTRY_ID_1D.3.6` (`COUNTRY_ID_1D.3.6`),
  KEY `STATE_ID_1D.3.4` (`STATE_ID_1D.3.4`),
  KEY `CITY_ID_1D.3.3` (`CITY_ID_1D.3.3`),
  CONSTRAINT `application_previous_employement_details_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `application_previous_employement_details_ibfk_2` FOREIGN KEY (`COUNTRY_ID_1D.3.6`) REFERENCES `countries` (`ID`),
  CONSTRAINT `application_previous_employement_details_ibfk_3` FOREIGN KEY (`STATE_ID_1D.3.4`) REFERENCES `states` (`ID`),
  CONSTRAINT `application_previous_employement_details_ibfk_4` FOREIGN KEY (`CITY_ID_1D.3.3`) REFERENCES `cities` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.cities
CREATE TABLE IF NOT EXISTS `cities` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `STATE_ID` int(11) NOT NULL,
  `CITY_NAME` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `STATE_ID` (`STATE_ID`),
  CONSTRAINT `cities_ibfk_1` FOREIGN KEY (`STATE_ID`) REFERENCES `states` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.citizenship_types
CREATE TABLE IF NOT EXISTS `citizenship_types` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CITIZENSHIP_TYPE` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.countries
CREATE TABLE IF NOT EXISTS `countries` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `COUNTRY_NAME` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `COUNTRY_NAME` (`COUNTRY_NAME`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.credit_types
CREATE TABLE IF NOT EXISTS `credit_types` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CREDIT_TYPE` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.declaration_categories
CREATE TABLE IF NOT EXISTS `declaration_categories` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DECLARATION_CATEGORY` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.declaration_questions
CREATE TABLE IF NOT EXISTS `declaration_questions` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DECLARATION_CATEGORY_ID` int(11) DEFAULT NULL,
  `PARENT_QUESTION_ID` int(11) DEFAULT NULL,
  `QUESTION` varchar(9999) CHARACTER SET utf8mb3 NOT NULL,
  `IS_ACTIVE` bit(1) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `DECLARATION_CATEGORY_ID` (`DECLARATION_CATEGORY_ID`),
  CONSTRAINT `declaration_questions_ibfk_1` FOREIGN KEY (`DECLARATION_CATEGORY_ID`) REFERENCES `declaration_categories` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.demographic_information
CREATE TABLE IF NOT EXISTS `demographic_information` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `ETHNICITY_8.1` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `GENDER_8.2` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `RACE_8.3` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `IS_ETHNICITY_BY_OBSERVATION_8.4` bit(1) DEFAULT NULL,
  `IS_GENDER_BY_OBSERVATION_8.5` bit(1) DEFAULT NULL,
  `IS_RACE_BY_OBSERVATION_8.6` bit(1) DEFAULT NULL,
  `DEMOGRAPHIC_INFO_SOURCE_ID_8.7` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `DEMOGRAPHIC_INFO_SOURCE_ID_8.7` (`DEMOGRAPHIC_INFO_SOURCE_ID_8.7`),
  CONSTRAINT `demographic_information_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `demographic_information_ibfk_2` FOREIGN KEY (`DEMOGRAPHIC_INFO_SOURCE_ID_8.7`) REFERENCES `demographic_info_sources` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.demographic_info_sources
CREATE TABLE IF NOT EXISTS `demographic_info_sources` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `VALUE` varchar(255) CHARACTER SET utf8mb3 DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.financial_account_types
CREATE TABLE IF NOT EXISTS `financial_account_types` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FINANCIAL_ACCOUNT_TYPE` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.financial_assets_types
CREATE TABLE IF NOT EXISTS `financial_assets_types` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FINANCIAL_CREDIT_TYPE` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.financial_laibilities_types
CREATE TABLE IF NOT EXISTS `financial_laibilities_types` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FINANCIAL_LAIBILITIES_TYPE` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.financial_other_laibilities_types
CREATE TABLE IF NOT EXISTS `financial_other_laibilities_types` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FINANCIAL_OTHER_LAIBILITIES_TYPE` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.financial_property_intended_occupancies
CREATE TABLE IF NOT EXISTS `financial_property_intended_occupancies` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FINANCIAL_PROPERTY_INTENDED_OCCUPANCY` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.financial_property_status
CREATE TABLE IF NOT EXISTS `financial_property_status` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FINANCIAL_PROPERTY_STATUS` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.housing_types
CREATE TABLE IF NOT EXISTS `housing_types` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `HOUSING_TYPE` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.income_sources
CREATE TABLE IF NOT EXISTS `income_sources` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `INCOME_SOURCE` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.income_types
CREATE TABLE IF NOT EXISTS `income_types` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `INCOME_TYPE` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.loan_and_property_information
CREATE TABLE IF NOT EXISTS `loan_and_property_information` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `LOAN_AMOUNT_4A.1` float DEFAULT NULL,
  `LOAN_PURPOSE_4A.2` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `PROPERTY_STREET_4A.3.1` varchar(200) CHARACTER SET utf8mb3 DEFAULT NULL,
  `PROPERTY_UNIT_NO_4A.3.2` varchar(20) CHARACTER SET utf8mb3 DEFAULT NULL,
  `PROPERTY_ZIP_4A.3.5` varchar(10) CHARACTER SET utf8mb3 DEFAULT NULL,
  `COUNTRY_ID_4A.3.6` int(11) NOT NULL,
  `STATE_ID_4A.3.4` int(11) NOT NULL,
  `CITY_ID_4A.3.3` int(11) NOT NULL,
  `PROPERTY_NUMBER_UNITS_4A.4` int(11) DEFAULT NULL,
  `PROPERTY_VALUE_4A.5` float DEFAULT NULL,
  `LOAN_PROPERTY_OCCUPANCY_ID_4A.6` int(11) DEFAULT NULL,
  `FHA_SECONDARY_RESIDANCE_4A.6.1` bit(1) DEFAULT NULL,
  `IS_MIXED_USE_PROPERTY_4A.7` bit(1) DEFAULT NULL,
  `IS_MANUFACTURED_HOME_4A.8` bit(1) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `COUNTRY_ID_4A.3.6` (`COUNTRY_ID_4A.3.6`),
  KEY `STATE_ID_4A.3.4` (`STATE_ID_4A.3.4`),
  KEY `CITY_ID_4A.3.3` (`CITY_ID_4A.3.3`),
  KEY `LOAN_PROPERTY_OCCUPANCY_ID_4A.6` (`LOAN_PROPERTY_OCCUPANCY_ID_4A.6`),
  CONSTRAINT `loan_and_property_information_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `loan_and_property_information_ibfk_2` FOREIGN KEY (`COUNTRY_ID_4A.3.6`) REFERENCES `countries` (`ID`),
  CONSTRAINT `loan_and_property_information_ibfk_3` FOREIGN KEY (`STATE_ID_4A.3.4`) REFERENCES `states` (`ID`),
  CONSTRAINT `loan_and_property_information_ibfk_4` FOREIGN KEY (`CITY_ID_4A.3.3`) REFERENCES `cities` (`ID`),
  CONSTRAINT `loan_and_property_information_ibfk_5` FOREIGN KEY (`LOAN_PROPERTY_OCCUPANCY_ID_4A.6`) REFERENCES `loan_property_occupancies` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.loan_and_property_information_gifts
CREATE TABLE IF NOT EXISTS `loan_and_property_information_gifts` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `LOAN_PROPERTY_GIFT_TYPE_ID_4D.1` int(11) DEFAULT NULL,
  `DEPOSITED_4D.2` bit(1) DEFAULT NULL,
  `SOURCE_4D.3` varchar(50) CHARACTER SET utf8mb3 DEFAULT NULL,
  `VALUE_4D.4` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  KEY `LOAN_PROPERTY_GIFT_TYPE_ID_4D.1` (`LOAN_PROPERTY_GIFT_TYPE_ID_4D.1`),
  CONSTRAINT `loan_and_property_information_gifts_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`),
  CONSTRAINT `loan_and_property_information_gifts_ibfk_2` FOREIGN KEY (`LOAN_PROPERTY_GIFT_TYPE_ID_4D.1`) REFERENCES `loan_property_gift_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.loan_and_property_information_other_mortage_loan
CREATE TABLE IF NOT EXISTS `loan_and_property_information_other_mortage_loan` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `CREDITOR_NAME_4B.1` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `LIEN_TYPE_4B.2` varchar(50) CHARACTER SET utf8mb3 DEFAULT NULL,
  `MONTHLY_PAYMENT_4B.3` float DEFAULT NULL,
  `LOAN_AMOUNT_4B.4` float DEFAULT NULL,
  `CREDIT_AMOUNT_4B.5` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  CONSTRAINT `loan_and_property_information_other_mortage_loan_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.loan_and_property_information_rental_income
CREATE TABLE IF NOT EXISTS `loan_and_property_information_rental_income` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `EXPECTED_MONTHLY_INCOME_4C.1` float DEFAULT NULL,
  `LENDER_EXPECTED_MONTHLY_INCOME_4C.2` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  CONSTRAINT `loan_and_property_information_rental_income_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.loan_originator_information
CREATE TABLE IF NOT EXISTS `loan_originator_information` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `ORGANIZATION_NAME_9.1` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ADDRESS_9.2` varchar(9999) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ORGANIZATION_NMLSR_ID_9.3` varchar(50) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ORGANIZATION_STATE_LICENCE_9.4` varchar(50) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ORIGINATOR_NAME_9.5` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ORIGINATOR_NMLSR_ID_9.6` varchar(30) CHARACTER SET utf8mb3 DEFAULT NULL,
  `ORIGINATOR_STATE_LICENSE_9.7` varchar(25) CHARACTER SET utf8mb3 DEFAULT NULL,
  `EMAIL_9.8` varchar(100) CHARACTER SET utf8mb3 DEFAULT NULL,
  `PHONE_9.9` varchar(25) CHARACTER SET utf8mb3 DEFAULT NULL,
  `DATE_9.10` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  CONSTRAINT `loan_originator_information_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.loan_property_gift_types
CREATE TABLE IF NOT EXISTS `loan_property_gift_types` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `LOAN_PROPERTY_GIFT_TYPE` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.loan_property_occupancies
CREATE TABLE IF NOT EXISTS `loan_property_occupancies` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `LOAN_PROPERTY_OCCUPANCY` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.maritial_status
CREATE TABLE IF NOT EXISTS `maritial_status` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `MARITIAL_STATUS` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.military_service
CREATE TABLE IF NOT EXISTS `military_service` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_PERSONAL_INFORMATION_ID` int(11) DEFAULT NULL,
  `SERVED_IN_FORCES_7A.1` bit(1) DEFAULT NULL,
  `CURRENTLY_SERVING_7A.2` bit(1) DEFAULT NULL,
  `DATE_OF_SERVICE_EXPIRATION_7A.3` datetime DEFAULT NULL,
  `RETIRED_7A.2` bit(1) DEFAULT NULL,
  `NON_ACTIVATED_MEMBER_7A.2` bit(1) DEFAULT NULL,
  `SURVIVING_SPOUSE_7A.2.1` bit(1) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_PERSONAL_INFORMATION_ID` (`APPLICATION_PERSONAL_INFORMATION_ID`),
  CONSTRAINT `military_service_ibfk_1` FOREIGN KEY (`APPLICATION_PERSONAL_INFORMATION_ID`) REFERENCES `application_personal_information` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.mortage_loan_on_properties
CREATE TABLE IF NOT EXISTS `mortage_loan_on_properties` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `APPLICATION_FINANCIAL_REAL_ESTATE_ID` int(11) DEFAULT NULL,
  `CREDITOR_NAME_3A.9` varchar(50) CHARACTER SET utf8mb3 NOT NULL,
  `ACCOUNT_NUMBER_3A.10` varchar(50) CHARACTER SET utf8mb3 NOT NULL,
  `MONTHLY_MORTAGE_PAYMENT_3A.11` float DEFAULT NULL,
  `UNPAID_BALANCE_3A.12` float DEFAULT NULL,
  `PAID_OFF_3A.13` bit(1) DEFAULT NULL,
  `MORTAGE_LOAN_TYPES_ID_3A.14` int(11) NOT NULL,
  `CREDIT_LIMIT_3A.15` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `APPLICATION_FINANCIAL_REAL_ESTATE_ID` (`APPLICATION_FINANCIAL_REAL_ESTATE_ID`),
  KEY `MORTAGE_LOAN_TYPES_ID_3A.14` (`MORTAGE_LOAN_TYPES_ID_3A.14`),
  CONSTRAINT `mortage_loan_on_properties_ibfk_1` FOREIGN KEY (`APPLICATION_FINANCIAL_REAL_ESTATE_ID`) REFERENCES `application_financial_real_estate` (`ID`),
  CONSTRAINT `mortage_loan_on_properties_ibfk_2` FOREIGN KEY (`MORTAGE_LOAN_TYPES_ID_3A.14`) REFERENCES `mortage_loan_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.mortage_loan_types
CREATE TABLE IF NOT EXISTS `mortage_loan_types` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `MORTAGE_LOAN_TYPES_ID` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table mortgagedb.states
CREATE TABLE IF NOT EXISTS `states` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `COUNTRY_ID` int(11) NOT NULL,
  `STATE_NAME` varchar(100) CHARACTER SET utf8mb3 NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `COUNTRY_ID` (`COUNTRY_ID`),
  CONSTRAINT `states_ibfk_1` FOREIGN KEY (`COUNTRY_ID`) REFERENCES `countries` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
