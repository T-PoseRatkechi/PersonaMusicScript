<script lang="ts">
	const example1 = `
floor[100]:
  music = 42
end
`.trim();
</script>

<h2>Floors (Persona 4 Golden and Persona 3 Portable)</h2>
<p>Set what music is used on a floor in the TV World or Tartarus.</p>
<h3>Floor Block</h3>
<div class="row">
	<div class="column">
		Between the <code>[ ]</code> brackets, set the <em>Floor ID</em> or a <em>collection</em> of
		Floor IDs you want to edit. Then use <code>music</code> to set the BGM used on those floor(s).
	</div>
	<div class="column">
		<pre><code>{example1}</code></pre>
	</div>
</div>
