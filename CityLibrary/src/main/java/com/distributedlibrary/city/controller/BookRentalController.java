package com.distributedlibrary.city.controller;

import com.distributedlibrary.city.dto.RegisterDTO;
import com.distributedlibrary.city.dto.RentalDTO;
import com.distributedlibrary.city.dto.ReturnDTO;
import com.distributedlibrary.city.model.BookRental;
import com.distributedlibrary.city.service.BookRentalService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestClientException;

import java.util.List;

@RestController
@RequiredArgsConstructor
@RequestMapping("/city")
public class BookRentalController {
    private final BookRentalService service;

    @PostMapping("/register")
    public ResponseEntity<String> register(@RequestBody RegisterDTO dto){
        try {
            final var response = service.register(dto);
            return ResponseEntity.status(HttpStatus.OK).body(response);
        } catch (RestClientException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }
    }

    @PostMapping("/rent")
    public ResponseEntity<?> rentBook(@RequestBody RentalDTO dto){
        try {
            final var response = service.rentBook(dto);
            return  response ?
                    ResponseEntity.status(HttpStatus.OK).body("Book successfully rented!"):
                    ResponseEntity.status(HttpStatus.NOT_FOUND).body("Specified book is already given away.");
        } catch (RestClientException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }
    }

    @PostMapping("/return")
    public ResponseEntity<?> returnBook(@RequestBody ReturnDTO dto){
        try {
            final var response = service.returnBook(dto);
            return  response ?
                    ResponseEntity.status(HttpStatus.OK).body("Book successfully returned!"):
                    ResponseEntity.status(HttpStatus.NOT_FOUND).body("Specified book doesn't exist.");
        } catch (RestClientException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }
    }

    @GetMapping("/all")
    public ResponseEntity<List<BookRental>> findAll(){
        return ResponseEntity.status(HttpStatus.OK).body(service.findAll());
    }
}
