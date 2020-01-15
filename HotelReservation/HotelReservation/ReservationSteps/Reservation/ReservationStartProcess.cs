﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.ReservationSteps.Reservation
{
    internal class ReservationStartProcess : IReservationStep
    {
        private readonly List<InputType> _requiredInputTypes = new List<InputType> { InputType.Name };

        public List<StepInput> GetRequiredStepInputs() => _requiredInputTypes.Select(type => new StepInput(type)).ToList();

        public virtual StepOutput Execute(List<StepInput> stepInputs)
        {
            string nameInput;
            try
            {
                nameInput = stepInputs.Find(stepInputData => stepInputData.Type == InputType.Name).Value;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("StepInput hasn't been correctly set!");
                //tu logowanie stacktrace
            }

            //temporary solution
            return string.IsNullOrEmpty(nameInput) ? 
                new StepOutput(false, "Your provided incorrect name") : 
                new StepOutput(true, "Your name: " + nameInput + "\nReservation start step finished with success!");

        }
    }
}
