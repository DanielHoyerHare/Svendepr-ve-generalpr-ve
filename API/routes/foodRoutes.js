import express from 'express'
import { 
    getFoods, 
    getFood, 
    search, 
    createFood, 
    deleteFood, 
    updateFood } from '../controllers/foodsController.js'

const router = express.Router();

router.get('/', getFoods);

router.get('/search/:id', getFood)

router.get('/search', search)

router.post('/', createFood)

router.delete('/:id', deleteFood)

router.put('/:id', updateFood)

export default router;