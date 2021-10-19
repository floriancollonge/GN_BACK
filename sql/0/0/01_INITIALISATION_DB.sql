CREATE DATABASE nursery  DEFAULT CHARACTER SET utf8 ;
USE nursery;

create table users (
    id_user varchar(100) not null,
    first_name varchar(50) not null,
    last_name varchar(50) not null,
    login varchar(200) not null,
    password varchar(300) not null,
    deleted tinyint(1) not null,
    primary key(id_user)
);

create table prospects (
    id_prospect varchar(100) not null,
    id_user integer not null references user(id_user),
    first_name varchar(50) not null,
    last_name varchar(50) not null,
    mail varchar200),
    phone varchar(15),
    id_step integer not null references process_step(id_step),
    last_contact_date datetime,
    next_contact_date datetime,
    date_insert datetime default CURRENT_TIMESTAMP,
    id_tag integer references tag(id_tag),
    primary key(id_prospect)

);

create table tags (
    id_tag varchar(100) not null,
    id_user integer not null references user(id_user),
    label varchar(50) not null,
    primary key(id_tag)
);

create table process_steps (
    id_step varchar(100) not null,
    id_user integer not null references user(id_user),
    label char(50) not null,
    position integer not null,
    number_days integer,
    primary key(id_step)
);