DROP TABLE IF EXISTS posts;

CREATE TABLE posts (
  id SERIAL PRIMARY KEY,
  sender varchar(45) NOT NULL,
  recipient varchar(45) NOT NULL,
  content varchar(1000) NOT NULL
);

INSERT INTO posts
("sender", "recipient", "content")
VALUES
('james', 'sam', 'Hi Sam, do you like my new social network?'),
('james', 'sam', 'Isn''t it great! What fun!'),
('sam', 'james', 'Hi James, yeah it''s great'),
('sam', 'james', 'If only you invented it 16 years ago you''d be a billionaire');
