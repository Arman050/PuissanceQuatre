CREATE TABLE joueurs (

pseudo varchar(50),
score int,

constraint uk_pseudo UNIQUE (pseudo)

)