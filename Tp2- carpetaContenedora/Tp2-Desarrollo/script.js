function fraseAleatoria() {
    var frases = [
      "La vida es como una caja de chocolates, nunca sabes lo que te va a tocar.",
      "La mejor manera de predecir el futuro es inventarlo.",
      "El éxito no es la clave de la felicidad. La felicidad es la clave del éxito. Si amas lo que estás haciendo, tendrás éxito.",
      "La vida es 10% lo que te sucede y 90% cómo reaccionas ante ello.",
      "No te preocupes por los fracasos, preocúpate por las oportunidades que pierdes al no intentarlo.",
      "La vida es una aventura atrevida o no es nada en absoluto.",
      "La felicidad no es algo hecho. Viene de tus propias acciones.",
       "La vida es como montar en bicicleta. Para mantener el equilibrio, debes seguir moviéndote.", 
       "El éxito no es la clave de la felicidad. La felicidad es la clave del éxito. Si amas lo que estás haciendo, tendrás éxito.",
       "La vida es 10% lo que te sucede y 90% cómo reaccionas ante ello.",
       "No te preocupes por los fracasos, preocúpate por las oportunidades que pierdes al no intentarlo.",
       "La mejor manera de predecir el futuro es inventarlo.",
       "La educación es el arma más poderosa que puedes usar para cambiar el mundo.",
       "El éxito no se trata de cuánto dinero tienes, sino de la diferencia que haces en la vida de las personas.",
       "Si quieres vivir una vida feliz, átala a una meta, no a personas o cosas."
        ];

  
    var indice = Math.floor(Math.random() * frases.length);
    return alert(frases[indice]);
  }
  