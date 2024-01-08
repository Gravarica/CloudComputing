package com.distributedlibrary.city.model;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.*;
import lombok.experimental.FieldDefaults;

import java.time.LocalDate;
import java.util.Date;
import java.util.UUID;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder(toBuilder = true)
@Table(name = "rentals")
@Entity(name = "book_rental")
@FieldDefaults(level = AccessLevel.PRIVATE)
public class BookRental {
    @Id
    @Column(nullable = false, updatable = false, unique = true)
    UUID id;

    @Column(nullable = false)
    String title;

    @Column(nullable = false)
    String author;

    @Column(nullable = false, unique = true)
    String isbn;

    @Column(nullable = false)
    UUID userId;

    @Column(nullable = false)
    LocalDate date;
}
