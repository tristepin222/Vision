CREATE DATABASE IF NOT EXISTS `Vision` DEFAULT CHARACTER SET utf8 ;
USE `Vision` ;

-- -----------------------------------------------------
-- Table `Vision`.`Image`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Vision`.`Image` ;

CREATE TABLE IF NOT EXISTS `Vision`.`Image` (
  `idImage` INT NOT NULL AUTO_INCREMENT,
  `Path` VARCHAR(45) NULL,
  PRIMARY KEY (`idImage`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Vision`.`Labels`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Vision`.`Labels` ;

CREATE TABLE IF NOT EXISTS `Vision`.`Labels` (
  `idLabels` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  `Confidence` VARCHAR(45) NULL,
  `Image_idImage` INT NOT NULL,
  PRIMARY KEY (`idLabels`, `Image_idImage`),
  INDEX `fk_Labels_Image_idx` (`Image_idImage` ASC) VISIBLE,
  CONSTRAINT `fk_Labels_Image`
    FOREIGN KEY (`Image_idImage`)
    REFERENCES `Vision`.`Image` (`idImage`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;
