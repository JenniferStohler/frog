CREATE TABLE accounts (
  id VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  picture VARCHAR(255) NOT NULL,

  PRIMARY KEY (id)

);
 
-- CREATE TABLE blogs (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR (255) NOT NULL,
--   type VARCHAR (255),
--   name VARCHAR (255) NOT NULL,
--   description VARCHAR (255) NOT NULL,
--   PRIMARY KEY (id),
--   FOREIGN KEY (creatorId)
--   REFERENCES accounts (id)
--   ON DELETE CASCADE
-- ) */


--  CREATE TABLE comments (
--   id INT NOT NULL AUTO_INCREMENT,
--   recipeId INT NOT NULL,
--   name VARCHAR (255) NOT NULL,
--   measurement VARCHAR (255) NOT NULL,
--   description VARCHAR (255),
--   PRIMARY KEY (id),
 
--   FOREIGN KEY (recipeId)
--   REFERENCES recipes (id)
--   ON DELETE CASCADE
-- ) */


--  /* GETALL */
--   SELECT * FROM accounts; 