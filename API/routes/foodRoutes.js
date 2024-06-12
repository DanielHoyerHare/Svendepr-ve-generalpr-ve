import express from 'express'
import { getFoods, getFood, search, createFood, deleteFood, updateFood } from '../controllers/foodsController.js'
import { authenticate } from '../middlewares/Authenticator.js';

const router = express.Router();

router.get('/', authenticate, getFoods);

router.get('/search/:id', authenticate, getFood)

router.get('/search', authenticate, search)

router.post('/', authenticate, createFood)

router.delete('/:id', authenticate, deleteFood)

router.put('/:id', authenticate, updateFood)

export default router;