import express from 'express'
import { getGoals, getGoal, search, createGoal, deleteGoal, updateGoal } from '../controllers/carController.js'

const router = express.Router();

router.get('/', getGoals);

router.get('/search/:id', getGoal)

router.get('/search', search)

router.post('/', createGoal)

router.delete('/:id', deleteGoal)

router.put('/:id', updateGoal)

export default router;