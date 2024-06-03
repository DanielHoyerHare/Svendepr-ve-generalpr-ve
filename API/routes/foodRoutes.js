import express from 'express'
import { getFood, getFood, search, createFood, deleteFood, updateFood } from '../controllers/carController.js'

const router = express.Router();

router.get('/', getFood);

router.get('/search/:id', getFood)

router.get('/search', search)

router.post('/', createFood)

router.delete('/:id', deleteFood)

router.put('/:id', updateFood)

export default router;