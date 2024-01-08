package com.distributedlibrary.city.mapper;

import com.distributedlibrary.city.dto.RentalDTO;
import com.distributedlibrary.city.model.BookRental;
import org.springframework.stereotype.Component;

import java.util.UUID;

@Component
public class BookRentalMapper {
    public BookRental DtoToEntity(RentalDTO dto){
        final var newRental = BookRental.builder()
                .id(UUID.randomUUID())
                .title(dto.getTitle())
                .author(dto.getAuthor())
                .isbn(dto.getIsbn())
                .userId(UUID.fromString(dto.getUserId()))
                .date(dto.getDate())
                .build();

        return newRental;
    }

}
