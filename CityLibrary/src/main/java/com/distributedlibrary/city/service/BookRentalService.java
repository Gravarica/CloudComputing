package com.distributedlibrary.city.service;

import com.distributedlibrary.city.dto.RegisterDTO;
import com.distributedlibrary.city.dto.RentalDTO;
import com.distributedlibrary.city.dto.ReturnDTO;
import com.distributedlibrary.city.mapper.BookRentalMapper;
import com.distributedlibrary.city.model.BookRental;
import com.distributedlibrary.city.repository.BookRentalRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestClientException;
import org.springframework.web.client.RestTemplate;

import java.util.List;
import java.util.UUID;

@Service
@RequiredArgsConstructor
public class BookRentalService {
    private final BookRentalRepository repository;
    private final BookRentalMapper mapper;
    private final RestTemplate restTemplate = new RestTemplate();
    @Value("${CENTRAL_APP_BASE_URL:http://localhost:5292}")
    private String baseUrl;

    public String register(RegisterDTO dto) throws RestClientException {
            var headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            System.out.println(dto.toString());
            ResponseEntity<String> response = restTemplate
                    .postForEntity(baseUrl+"/register", new HttpEntity<>(dto, headers), String.class);
            return response.getBody();
    }

    public boolean rentBook(RentalDTO dto) throws RestClientException {
        var bookId = repository.findByISBN(dto.getIsbn());
        if(bookId != null) return false;
        return executeRent(dto);
    }

    private boolean executeRent(RentalDTO dto) throws RestClientException {
            var headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            restTemplate.put(String.format(baseUrl+"/rent/%s", dto.getUserId()), new HttpEntity<>("", headers), Boolean.class);
            var newRental = mapper.DtoToEntity(dto);
            repository.save(newRental);
            return true;
    }

    public boolean returnBook(ReturnDTO dto) throws RestClientException {
        var bookId = repository.findByISBN(dto.getIsbn());
        if(bookId == null) return false;
        return executeReturn(bookId, dto.getUserId());
    }

    private boolean executeReturn(UUID bookId, String userId) throws RestClientException {
            var headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            restTemplate.put(String.format(baseUrl+"/return/%s", userId), new HttpEntity<>("", headers), Boolean.class);
            repository.deleteById(bookId);
            return true;
    }

    public List<BookRental> findAll(){
        return repository.findAll();
    }
}
